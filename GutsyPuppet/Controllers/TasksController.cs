using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GutsyPuppet.Model.Repositories.EFRepositories;
using GutsyPuppet.Model.Repositories.Interfaces;
using GutsyPuppet.Models;

namespace GutsyPuppet.Controllers
{
    public class TasksController : Controller
    {

        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly WorkflowStepRepository _workflowStepRepository;

        public TasksController()
        {
            var contextRepository = new ContextRepository();
            _userRepository = new UserRepository(contextRepository);
            _taskRepository = new TaskRepository(contextRepository, _userRepository);
            _workflowStepRepository = new WorkflowStepRepository(contextRepository);
        }

        // GET: Tasks
        public ActionResult Index(int teamId)
        {
            var date = DateTime.UtcNow;
            var tasksViewModel = new TasksViewModel();
            tasksViewModel.Date = date;


            var users = _userRepository.GetUsersForTeam(teamId).Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.UserId
            }).OrderBy(u => u.FirstName).ThenBy(u => u.LastName).ToList();

            var allUsers = _userRepository.GetAllActiveUsers().Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.UserId
            }).ToList() // First perform a query cause LINQ doesn't support the $ string method
            .Select(u => new
            {
                Name = $"{u.FirstName} {u.LastName}",
                u.UserId
            }).ToList();

            var allWorkflowSteps = _workflowStepRepository.GetAllTaskWorkflowSteps().ToList();

            var tasks = _taskRepository.GetTasksForTeamBeforeDay(teamId, date)
                .Select(t => new
                {
                    UserId = t.AssignedToId,
                    Title = t.Name,
                    RemainingHours = (t.RemainingUnitTypeId == 1 ? t.RemainingDuration / 60.0 : t.RemainingDuration),
                    t.ReportedById,
                    t.StartDate,
                    t.WorkflowStepId
                }).ToList();


            var taskUsers = new List<TasksViewModel.TaskUser>();
            foreach (var user in users)
            {
                var taskUser = new TasksViewModel.TaskUser();
                taskUser.Name = $"{user.FirstName} {user.LastName}";
                var userTasks = tasks.Where(t => t.UserId == user.UserId)
                    .Select(t => new TasksViewModel.Task
                    {
                        RemainingHours = t.RemainingHours,
                        StartDate = t.StartDate.Value,
                        Title = t.Title,
                        ReportedBy = allUsers.SingleOrDefault(u => u.UserId == t.ReportedById)?.Name,
                        WorkflowStep =
                            allWorkflowSteps.SingleOrDefault(w => w.WorkflowStepId == t.WorkflowStepId)?.StepName
                    });

                taskUser.Tasks = userTasks;
                taskUsers.Add(taskUser);
            }
            tasksViewModel.TaskUsers = taskUsers;

            return PartialView(tasksViewModel);
        }
    }
}
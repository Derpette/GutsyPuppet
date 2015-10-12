using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GutsyPuppet.Model.Repositories.EFRepositories;
using GutsyPuppet.Model.Repositories.Interfaces;
using GutsyPuppet.Models;
using GutsyPuppet.Models.Helpers;

namespace GutsyPuppet.Controllers
{
    public class WorklogsController : Controller
    {

        private readonly IWorklogRepository _worklogRepository;
        private readonly IUserRepository _userRepository;

        public WorklogsController()
        {
            var contextRepository = new ContextRepository();
            _userRepository = new UserRepository(contextRepository);
            _worklogRepository = new WorklogRepository(contextRepository, _userRepository);
        }

        // GET: Worklogs
        public ActionResult Index(int teamId)
        {
            var previousWorkday = DateHelper.GetPreviousWorkday();
            var worklogsViewModel = new WorklogsViewModel();
            worklogsViewModel.Date = previousWorkday;

            var users = _userRepository.GetUsersForTeam(teamId).Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.UserId
            }).OrderBy(u => u.FirstName).ThenBy(u => u.LastName).ToList();
            var worklogs = _worklogRepository.GetWorklogsOfTeamForDay(teamId, previousWorkday).Select(w => new
            {
                w.UserId,
                w.WorkUnitTypeId,
                w.WorkDone
            }).ToList();
            var worklogUsers = new List<WorklogsViewModel.WorklogUser>();
            foreach (var user in users)
            {
                var worklogUser = new WorklogsViewModel.WorklogUser();
                worklogUser.Name = $"{user.FirstName} {user.LastName}";
                var userWorklogs =
                    worklogs.Where(w => w.UserId == user.UserId)
                        .Select(w => new {Hours = (w.WorkUnitTypeId == 1 ? w.WorkDone/60.0 : w.WorkDone)});

                worklogUser.LoggedHours = userWorklogs.Sum(w => w.Hours);
                worklogUsers.Add(worklogUser);
            }
            worklogsViewModel.WorklogUsers = worklogUsers;

            return PartialView(worklogsViewModel);
        }
    }
}
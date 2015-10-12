using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GutsyPuppet.Model.Repositories.Interfaces;

namespace GutsyPuppet.Model.Repositories.EFRepositories
{
    public class TaskRepository : ITaskRepository
    {
        private IContextRepository _contextRepository;
        private IUserRepository _userRepository;

        public TaskRepository(IContextRepository contextRepository, IUserRepository userRepository)
        {
            _contextRepository = contextRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets all tasks of a team for a day and before the day
        /// Read-only, uses 'no-tracking'
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public IQueryable<OnTimeItem> GetTasksForTeamBeforeDay(int teamId, DateTime day)
        {
            var users = _userRepository.GetUsersForTeam(teamId).Select(u => u.UserId);
            var endDate = day.Date.AddDays(1);
            var minimalDate = new DateTime(1899, 1, 1);
            var tasks = _contextRepository.Context.OnTimeItems
                .Where(i => (i.StartDate.HasValue && i.StartDate < endDate && i.StartDate > minimalDate) &&
                (!i.IsCompleted.HasValue || !i.IsCompleted.Value) && i.WorkflowStepId != 21 // 21 is 'Completed', have to use seeing as 'IsCompleted' doesn't work completely
                && i.ItemType == 2
                && (users.Contains(i.AssignedToId) && i.AssignedToType == 0))
                .AsNoTracking()
                ;

            return tasks;
        }

    }
}

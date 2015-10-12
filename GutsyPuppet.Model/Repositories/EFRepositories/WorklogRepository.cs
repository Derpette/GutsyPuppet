using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GutsyPuppet.Model.Repositories.Interfaces;

namespace GutsyPuppet.Model.Repositories.EFRepositories
{
    public class WorklogRepository : IWorklogRepository
    {
        private IContextRepository _contextRepository;
        private IUserRepository _userRepository;

        public WorklogRepository(IContextRepository contextRepository, IUserRepository userRepository)
        {
            _contextRepository = contextRepository;
            _userRepository = userRepository;
        }

        public IQueryable<WorkLog> GetWorklogsOfTeamForDay(int teamId, DateTime day)
        {
            var users = _userRepository.GetUsersForTeam(teamId).Select(u => u.UserId);
            var worklogs = _contextRepository.Context.WorkLogs.AsNoTracking().Where(w => users.Contains(w.UserId));
            // Now check for date
            var dayStart = day;
            var dayEnd = dayStart.AddDays(1).Date;
            worklogs = worklogs.Where(w => w.WorkLogDateTime >= dayStart && w.WorkLogDateTime < dayEnd);
            return worklogs;
        } 

        public IQueryable<WorkLog> GetPreviousWorkdayLogsForTeam(int teamId)
        {
            var users = _userRepository.GetUsersForTeam(teamId).Select(u => u.UserId);
            var worklogs = _contextRepository.Context.WorkLogs.AsNoTracking().Where(w => users.Contains(w.UserId));
            // Now check for date
            var previousWorkdayStart = GetPreviousWorkday();
            var previousWorkdayEnd = previousWorkdayStart.AddDays(1).Date;
            worklogs = worklogs.Where(w => w.WorkLogDateTime >= previousWorkdayStart && w.WorkLogDateTime < previousWorkdayEnd);
            return worklogs;
        }

        private DateTime GetPreviousWorkday()
        {
            var now = DateTime.UtcNow;
            DateTime previous = now;
            do
            {
                previous = previous.AddDays(-1);
            } while (previous.DayOfWeek == DayOfWeek.Saturday || previous.DayOfWeek == DayOfWeek.Sunday);
            return previous.Date;
        }

    }
}

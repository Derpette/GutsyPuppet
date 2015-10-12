using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GutsyPuppet.Model.Repositories.Interfaces
{
    public interface IWorklogRepository
    {

        IQueryable<WorkLog> GetWorklogsOfTeamForDay(int teamId, DateTime day);
        IQueryable<WorkLog> GetPreviousWorkdayLogsForTeam(int teamId);

    }
}

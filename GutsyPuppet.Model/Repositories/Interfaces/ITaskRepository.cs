using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GutsyPuppet.Model.Repositories.Interfaces
{
    public interface ITaskRepository
    {

        IQueryable<OnTimeItem> GetTasksForTeamBeforeDay(int teamId, DateTime day);

    }
}

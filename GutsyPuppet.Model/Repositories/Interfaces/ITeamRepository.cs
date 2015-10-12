using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GutsyPuppet.Model.Model;

namespace GutsyPuppet.Model.Repositories.Interfaces
{
    public interface ITeamRepository
    {

        IEnumerable<Team> GetTeams();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GutsyPuppet.Model.Model;
using GutsyPuppet.Model.Repositories.Interfaces;

namespace GutsyPuppet.Model.Repositories.EFRepositories
{
    public class TeamRepository : ITeamRepository
    {

        private IContextRepository _contextRepository;

        public TeamRepository(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public IEnumerable<Team> GetTeams()
        {
            var teams = _contextRepository.Context.Database.SqlQuery<Team>("SELECT TeamLevel," +
                                                               "TeamId, ParentId," +
                                                               "Name FROM Teams");
            return teams;
        }

    }
}

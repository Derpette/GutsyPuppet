using System;
using System.Data.Entity;
using System.Linq;
using GutsyPuppet.Model.Repositories.Interfaces;

namespace GutsyPuppet.Model.Repositories.EFRepositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IContextRepository _contextRepository;

        public UserRepository(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        /// <summary>
        /// Get users for a team
        /// Read-only, uses 'no-tracking'
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public IQueryable<User> GetUsersForTeam(int teamId)
        {
            if (teamId == -1)
            {
                return GetAllActiveUsers();
            }

            var userIds = _contextRepository.Context.TeamUsers.Where(tu => tu.TeamId == teamId).Select(tu => tu.UserId);
            return _contextRepository.Context.Users.Where(u => userIds.Contains(u.UserId) && u.IsActive).AsNoTracking();
        }

        /// <summary>
        /// Gets all users
        /// Read-only, uses 'no-tracking'
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> GetAllActiveUsers()
        {
            return _contextRepository.Context.Users.Where(u => u.IsActive).AsNoTracking();
        }
    }
}

using System.Linq;

namespace GutsyPuppet.Model.Repositories.Interfaces
{
    public interface IUserRepository
    {

        IQueryable<User> GetUsersForTeam(int teamId);
        IQueryable<User> GetAllActiveUsers();

    }
}

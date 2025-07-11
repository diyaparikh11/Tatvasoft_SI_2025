using Mission.Entities.Models;

namespace Mission.Repositories
{
    public interface IUserRepository
    {
        User ValidateUser(string username, string password);
    }
}

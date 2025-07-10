using System.Linq;
using Mission.Entities;
using Mission.Entities.Models;

namespace Mission.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MissionDBContext _context;

        public UserRepository(MissionDBContext context)
        {
            _context = context;
        }

        public User ValidateUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}

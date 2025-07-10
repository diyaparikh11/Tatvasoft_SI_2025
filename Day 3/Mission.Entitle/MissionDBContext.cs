using Microsoft.EntityFrameworkCore;
using Mission.Entities.Models;

namespace Mission.Entities
{
    public class MissionDBContext : DbContext
    {
        public MissionDBContext(DbContextOptions<MissionDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

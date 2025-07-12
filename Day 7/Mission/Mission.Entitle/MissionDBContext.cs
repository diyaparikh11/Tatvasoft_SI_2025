using Microsoft.EntityFrameworkCore;
using Mission.Entities.Models;

public class MissionDBContext : DbContext
{
    public MissionDBContext(DbContextOptions<MissionDBContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<MissionTheme> MissionThemes { get; set; }
    public DbSet<MissionSkill> MissionSkills { get; set; }
    public DbSet<MissionModel> Missions { get; set; }
}

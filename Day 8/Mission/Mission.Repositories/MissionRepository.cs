using Mission.Entities;
using Mission.Entities.Models;
using Microsoft.EntityFrameworkCore;

public class MissionRepository : IMissionRepository
{
    private readonly MissionDBContext _context;

    public MissionRepository(MissionDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MissionModel>> GetAllMissionsAsync()
    {
        return await _context.Missions.ToListAsync();
    }

    public async Task<MissionModel> AddMissionAsync(MissionModel mission)
    {
        _context.Missions.Add(mission);
        await _context.SaveChangesAsync();
        return mission;
    }
}
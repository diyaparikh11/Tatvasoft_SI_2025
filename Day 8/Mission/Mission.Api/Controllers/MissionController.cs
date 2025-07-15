using Microsoft.AspNetCore.Mvc;
using Mission.Entities.Models;
using Mission.Repositories;

[ApiController]
[Route("api/[controller]")]
public class MissionController : ControllerBase
{
    private readonly IMissionRepository _missionRepo;

    public MissionController(IMissionRepository missionRepo)
    {
        _missionRepo = missionRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetMissions()
    {
        var missions = await _missionRepo.GetAllMissionsAsync();
        return Ok(missions);
    }

    [HttpPost]
    public async Task<IActionResult> AddMission(MissionModel mission)
    {
        var created = await _missionRepo.AddMissionAsync(mission);
        return Ok(created);
    }
}

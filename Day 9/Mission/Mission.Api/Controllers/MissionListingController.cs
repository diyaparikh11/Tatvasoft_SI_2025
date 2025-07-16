using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MissionListingController : ControllerBase
{
    private readonly MissionDBContext _context;

    public MissionListingController(MissionDBContext context)
    {
        _context = context;
    }

    // GET: api/MissionListing
    [HttpGet]
    public IActionResult GetMissions()
    {
        var missions = _context.Missions.ToList();
        return Ok(missions);
    }

    // Optional: filter by theme
    [HttpGet("filter/theme/{theme}")]
    public IActionResult GetByTheme(string theme)
    {
        var missions = _context.Missions.Where(m => m.Theme == theme).ToList();
        return Ok(missions);
    }
}

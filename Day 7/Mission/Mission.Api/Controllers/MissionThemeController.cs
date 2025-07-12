using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;

[ApiController]
[Route("api/[controller]")]
public class MissionThemeController : ControllerBase
{
    private readonly MissionDBContext _context;

    public MissionThemeController(MissionDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.MissionThemes.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var theme = _context.MissionThemes.Find(id);
        return theme == null ? NotFound() : Ok(theme);
    }

    [HttpPost]
    public IActionResult Create(MissionTheme theme)
    {
        _context.MissionThemes.Add(theme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = theme.Id }, theme);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, MissionTheme updated)
    {
        var theme = _context.MissionThemes.Find(id);
        if (theme == null) return NotFound();

        theme.Title = updated.Title;
        theme.Description = updated.Description;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTheme(int id)
    {
        var theme = _context.MissionThemes.Find(id);
        if (theme == null)
            return NotFound();

        _context.MissionThemes.Remove(theme);
        _context.SaveChanges();

        return NoContent();
    }

}

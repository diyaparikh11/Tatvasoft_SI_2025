using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;

[ApiController]
[Route("api/[controller]")]
public class MissionSkillController : ControllerBase
{
    private readonly MissionDBContext _context;

    public MissionSkillController(MissionDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.MissionSkills.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var skill = _context.MissionSkills.Find(id);
        if (skill == null) return NotFound();
        return Ok(skill);
    }

    [HttpPost]
    public IActionResult Create(MissionSkill skill)
    {
        _context.MissionSkills.Add(skill);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = skill.Id }, skill);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, MissionSkill updated)
    {
        var skill = _context.MissionSkills.Find(id);
        if (skill == null) return NotFound();

        skill.SkillName = updated.SkillName;
        skill.Description = updated.Description;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var skill = _context.MissionSkills.Find(id);
        if (skill == null) return NotFound();

        _context.MissionSkills.Remove(skill);
        _context.SaveChanges();
        return NoContent();
    }
}

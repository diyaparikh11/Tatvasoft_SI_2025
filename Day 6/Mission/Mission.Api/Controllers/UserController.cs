using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Entities.Models;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly MissionDBContext _context;

    public UserController(MissionDBContext context)
    {
        _context = context;
    }

    // GET: All Users
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    // GET: api/User/query?search=admin&sort=asc&page=1&pageSize=5
    [HttpGet("query")]
    public IActionResult QueryUsers(string? search, string? sort = "asc", int page = 1, int pageSize = 5)
    {
        var query = _context.Users.AsQueryable();

        // Filter
        if (!string.IsNullOrEmpty(search))
            query = query.Where(u => u.Username.Contains(search) || u.Email.Contains(search));

        // Sort
        query = sort == "desc"
            ? query.OrderByDescending(u => u.Username)
            : query.OrderBy(u => u.Username);

        // Paging
        var totalRecords = query.Count();
        var users = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Ok(new
        {
            totalRecords,
            page,
            pageSize,
            users
        });
    }

    // GET: User by ID
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    // POST: Add user
    [HttpPost]
    public IActionResult Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    // PUT: Update user
    [HttpPut("{id}")]
    public IActionResult Update(int id, User updated)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();

        user.Username = updated.Username;
        user.Password = updated.Password;
        user.Email = updated.Email;
        user.Role = updated.Role;

        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: Remove user
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}

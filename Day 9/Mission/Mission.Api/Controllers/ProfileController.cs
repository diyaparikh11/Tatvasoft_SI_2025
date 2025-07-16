using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly MissionDBContext _context;

    public ProfileController(MissionDBContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public IActionResult GetProfile(int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return NotFound();

        var profile = new UserProfile
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Bio = "Sample bio", // You can add a field to DB later
            ProfileImageUrl = "" // Add image URL field in DB or return default
        };

        return Ok(profile);
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateProfile(int userId, [FromBody] UserProfile updated)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return NotFound();

        user.Email = updated.Email;
        user.Username = updated.Username;
        // Save bio/profile image in DB if added

        _context.SaveChanges();
        return Ok("Profile updated.");
    }
}

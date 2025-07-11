using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mission.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("Hello Admin");
        }

        [Authorize(Roles = "User")]
        [HttpGet("user-dashboard")]
        public IActionResult UserDashboard()
        {
            return Ok("Hello User");
        }
    }
}

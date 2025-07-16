using Microsoft.AspNetCore.Mvc;
using Mission.Entities.Models;
using Mission.Repositories;

namespace Mission.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionApplicationController : ControllerBase
    {
        private readonly IMissionApplicationRepository _repository;

        public MissionApplicationController(IMissionApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var app = _repository.GetById(id);
            return app == null ? NotFound() : Ok(app);
        }

        [HttpPost]
        public IActionResult Add(MissionApplication app)
        {
            _repository.Add(app);
            return Ok(app);
        }

        [HttpPut]
        public IActionResult Update(MissionApplication app)
        {
            _repository.Update(app);
            return Ok(app);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId) => Ok(_repository.GetByUserId(userId));
    }
}
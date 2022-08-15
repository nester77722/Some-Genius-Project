using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using BoardGames.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        private readonly IMechanicService _mechanicService;

        public MechanicController(IMechanicService mechanicService)
        {
            _mechanicService = mechanicService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MechanicDto mechanicDto)
        {
            mechanicDto = await _mechanicService.CreateAsync(mechanicDto);

            Log.Information($"Added mechanic with id: {mechanicDto.Id} to database.");

            return Ok(mechanicDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mechanics = await _mechanicService.GetAllAsync();

            return Ok(mechanics);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var genre = await _mechanicService.GetAsync(id);

            if (genre is null)
            {
                return NotFound(new { Message = $"Mechanic with id {id} was not found!" });
            }

            return Ok(genre);
        }
    }
}

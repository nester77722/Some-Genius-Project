using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
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
        public async Task<IActionResult> Create([FromBody] CreateMechanicDto mechanicDto)
        {
            var result = await _mechanicService.CreateAsync(mechanicDto);

            Log.Information($"Added mechanic with id: {result.Id} to database.");

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mechanics = await _mechanicService.GetAllWithoutGamesAsync();

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

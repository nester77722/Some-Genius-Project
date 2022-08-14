using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GameDto gameDto)
        {
            gameDto = await _gameService.CreateAsync(gameDto);

            Log.Information($"Added mechanic with id: {gameDto.Id} to database.");

            return Ok(gameDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();

            return Ok(games);
        }
    }
}

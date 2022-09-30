using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateGenreDto genreDto)
        {
            var result = await _genreService.CreateAsync(genreDto);

            Log.Information($"Added genre with id: {result.Id} to database.");

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreService.GetAllWithoutGamesAsync();

            return Ok(genres);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var genre = await _genreService.GetAsync(id);

            if (genre is null)
            {
                return NotFound(new { Message = $"Genre with id {id} was not found!" });
            }

            return Ok(genre);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _genreService.DeleteAsync(id);

            return Ok();
        }
    }
}

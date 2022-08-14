using BoardGames.API.Models;
using BoardGames.Data.Entities;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;

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
        public async Task<IActionResult> Create([FromBody] GenreDto genreDto)
        {
            genreDto = await _genreService.CreateAsync(genreDto);

            Log.Information($"Added genre with id: {genreDto.Id} to database.");

            return Ok(genreDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreService.GetAllAsync();

            return Ok(genres);
        }
    }
}

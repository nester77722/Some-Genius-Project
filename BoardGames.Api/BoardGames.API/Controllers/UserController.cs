using BoardGames.Data.Entities;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using BoardGames.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetInfo()
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var user = await _userService.GetUserInfo(userId);

            if (user is null)
            {
                return NotFound(new { Message = $"User with id {userId} was not found!" });
            }

            return Ok(user);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateInfo([FromForm] UserDto user)
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            try
            {
                var userIdGuid = Guid.Parse(userId);
                var userDtoIdGuid = Guid.Parse(user.Id);

                if (userIdGuid != userDtoIdGuid)
                {
                    return Unauthorized();

                }
            }
            catch
            {
                return BadRequest();
            }

            var result = await _userService.UpdateUserInfo(user);

            return Ok(result);
        }

    }
}

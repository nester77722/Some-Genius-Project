using BoardGames.API.Models;
using BoardGames.API.Services.Interfaces;
using BoardGames.Data.Entities;
using BoardGames.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Serilog;
using System.Security.Claims;

namespace BoardGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid || loginModel == null)
            {
                Log.Information("Error in trying to login.");
                throw new LoginException("Invalid client request.");
            }

            User user = await ValidateUser(loginModel);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            return Ok(new TokensDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid || registerModel == null)
            {
                throw new RegisterException("Invalid client request.");
            }

            var user = new User()
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                throw new RegisterException(result.Errors.Select(e => e.Description));
            }

            result = await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
            {
                throw new RegisterException(result.Errors.Select(e => e.Description));
            }

            return Ok(new { Message = "User Reigstration Successful" });
        }

        private IActionResult ReturnBadRequest(IEnumerable<IdentityError> errors)
        {
            var dictionary = new ModelStateDictionary();
            var errorStrings = string.Empty;
            var response = new
            {
                Message = "User Registration Failed",
                Errors = new List<string>()
            };

            foreach (var error in errors)
            {
                dictionary.AddModelError(error.Code, error.Description);
                errorStrings += $"Error code: {error.Code}, error description: {error.Description}\n";
                response.Errors.Add(error.Description);
            }
            Log.Error($"Error in trying to register. Errors: \n{errorStrings}");

            return new BadRequestObjectResult(response);
        }

        private async Task<User> ValidateUser(LoginModel loginModel)
        {
            var identityUser = await _userManager.FindByNameAsync(loginModel.UserName);

            if (identityUser is null)
            {
                throw new LoginException("Incorrect username.");
            }

            var result = _userManager
                            .PasswordHasher
                            .VerifyHashedPassword(identityUser, identityUser.PasswordHash, loginModel.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new LoginException("Incorrect password.");
            }

            return identityUser;
        }
    }
}
using Microsoft.AspNetCore.Identity;

namespace BoardGames.Data.Entities
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}

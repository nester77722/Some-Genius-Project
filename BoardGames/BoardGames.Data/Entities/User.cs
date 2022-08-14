using Microsoft.AspNetCore.Identity;

namespace BoardGames.Data.Entities
{
    public class User : IdentityUser<Guid>, IEntity
    {
    }
}

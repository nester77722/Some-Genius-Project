using BoardGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Services.Intefraces
{
    public interface IUserService
    {
        public Task<UserDto> UpdateUserInfo(UserDto userDto);
        public Task<UserDto> GetUserInfo(string id);
    }
}

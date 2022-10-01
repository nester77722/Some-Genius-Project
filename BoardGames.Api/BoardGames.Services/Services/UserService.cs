using AutoMapper;
using BoardGames.Data.Entities;
using BoardGames.Data.Repository;
using BoardGames.Services.Helpers;
using BoardGames.Services.Intefraces;
using BoardGames.Services.Models;
using BoardGames.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserInfo(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            Guid userId;

            if (!Guid.TryParse(id, out userId))
            {
                return null;
            }

            var user = await _repository.GetAsync(userId, include => include.Image);

            if (user is null)
            {
                return null;
            }

            var result = _mapper.Map<UserDto>(user);

            return result;
        }

        public async Task<UserDto> UpdateUserInfo(UserDto userDto)
        {
            Guid userId;

            if (!Guid.TryParse(userDto.Id, out userId))
            {
                throw new ServiceException($"User not found with id {userDto.Id}", "UserService");
            }


            var user = await _repository.GetAsync(userId, include => include.Image);

            user.Name = CheckIsNull(userDto.Name) ? string.Empty : userDto.Name;

            user.Surname = CheckIsNull(userDto.Surname) ? string.Empty : userDto.Surname;
            user.Age = userDto.Age;

            if (userDto.Image is not null)
            {
                user.Image.ImageData = ImageHelper.ResizeImage(userDto.Image);
                user.Image.ThumbnailData = ImageHelper.CreateThumbnail(userDto.Image);
            }

            await _repository.UpdateAsync(user);

            var result = _mapper.Map<UserDto>(user);

            return result;
        }

        private bool CheckIsNull(string value)
        {
            return value == "null";
        }
    }
}

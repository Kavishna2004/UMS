using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.DTOS;
using UMSAssignment.MODELS;

namespace UMSAssignment.MAPPERS
{
    internal static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Role = user.Role
            };
        }
        public static User ToEntity(UserDto userDto, string password = null)
        {
            if (userDto == null) return null;

            return new User
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Role = userDto.Role,
                Password = password
            };
        }
    }
}

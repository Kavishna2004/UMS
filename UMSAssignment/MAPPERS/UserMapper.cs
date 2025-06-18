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
                UserEmail = user.UserEmail,
                Role = user.Role
            };
        }

        public static User ToEntity(UserDto userDto, string passwordHash = null)
        {
            if (userDto == null) return null;

            return new User
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                UserEmail = userDto.UserEmail,
                Role = userDto.Role,
                PasswordHash = passwordHash 
            };
        }
    }
}

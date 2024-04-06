using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class  UserMappers
    {
        public static UserDto ToUserDto(this User userModel){
            return new UserDto {
                UserId=userModel.UserId,
                Username=userModel.Username,
                Password=userModel.Password,
                Role=userModel.Role,



            };
        }
           public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Username=userDto.Username,
                Password=userDto.Password,
                Role=userDto.Role,
            };
        }
    }
}
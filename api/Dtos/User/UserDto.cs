using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserDto
    {
    public int UserId { get; set; }
    public string Username { get; set; }=string.Empty ;
    public string Password { get; set; }=string.Empty ;
    public string Role { get; set; }=string.Empty;
    }
}
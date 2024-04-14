using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  //  [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
      [Route("api/user")]
    [ApiController]
    
     public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo ;
      public UserController(ApplicationDBContext context,IUserRepository userRepo)
      {
        _userRepo=userRepo ;
        _context = context;

      }
           [HttpGet]
           public async Task<IActionResult> GetAll(){
            // var users= await _context.Users.ToListAsync();
            var users= await _userRepo.GetAllAsync();
            var userDto= users.Select(s=> s.ToUserDto());
            return Ok(users);

           }
           [HttpGet("{id}")]
           public async Task<IActionResult> GetUserById([FromRoute] int id){
            var users= await _userRepo.GetByIdAsync(id );
            if(users==null){
            return NotFound();
            }
            return Ok(users.ToUserDto());
           }

             [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
           

            var userModel = userDto.ToUserFromCreateDTO();
              await _userRepo.CreateAsync(userModel);

             return CreatedAtAction(nameof(GetUserById), new { id = userModel.UserId }, userModel.ToUserDto());
        }
         [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        { 
           

            var userModel =  await _userRepo.UpdateAsync(id,updateDto);

            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel.ToUserDto());
        }
          [HttpDelete]
        [Route("{id}")]
        public  async Task<IActionResult> Delete ([FromRoute] int id)
        {
           

            var userModel = await _userRepo.DeleteAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }
          
            return NoContent() ;
        }
}
}
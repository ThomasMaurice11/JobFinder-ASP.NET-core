using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context ;
        public UserRepository(ApplicationDBContext context)
        {
            _context= context ;
        }
        public Task<List<User>> GetAllAsync()
        {
           return _context.Users.ToListAsync() ;
        }
         public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (userModel == null)
            {
                return null;
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }
         public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        //    public async Task<User?> UpdateAsync(int id,UpdateUserRequestDto userDto)
        // {
        //     return await _context.Users.FindAsync(id);
        // }

  public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            var existingStock = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (existingStock == null)
            {
                return null;
            }

            existingStock.Username=userDto.Username ;
            existingStock.Password=userDto.Password ;
            existingStock.Role=userDto.Role ;

            await _context.SaveChangesAsync();

            return existingStock;
        }

    }
}
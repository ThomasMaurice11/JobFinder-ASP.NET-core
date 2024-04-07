using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  
    public class JobRepository :IJobRepository 
    {
         private readonly ApplicationDBContext _context ;
        public JobRepository(ApplicationDBContext context)
        {
            _context=context ;
        }
        public async Task<List<Job>> GetAllAsync()
        {
            return await _context.Jobs.ToListAsync() ;
        }
        // public async Task<Job> CreateAsync(Job userModel)
        // {
        // return await _context.Jobs.Add(userModel);
        // }

       

        // public Task<Job?> GetByIdAsync(int id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
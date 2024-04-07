using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IJobRepository
    {
          Task<List<Job>> GetAllAsync();
        //     Task<Job?> GetByIdAsync(int id);
        // Task<Job> CreateAsync(Job userModel);
          
    }
}
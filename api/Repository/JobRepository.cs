using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Job;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace api.Repository
{
  
    public class JobRepository :IJobRepository 
    {
         private readonly ApplicationDBContext _context ;
        public JobRepository(ApplicationDBContext context)
        {
            _context=context ;
        }

        public async Task<Job> CreateAsync(Job jobModel)
        {
           await _context.Jobs.AddAsync(jobModel);
           await _context.SaveChangesAsync();
           return jobModel ;
        }

      

        public async Task<Job?> DeleteAsync(int id)
        {
            var jobModel = await _context.Jobs.FirstOrDefaultAsync(x => x.JobId == id);

            if (jobModel == null)
            {
                return null;
            }

            _context.Jobs.Remove(jobModel);
            await _context.SaveChangesAsync();
            return jobModel;
        }

       

        public async Task<List<Job>> GetAllAsync()
        {
            return await _context.Jobs.ToListAsync() ;
        }


       

          public async Task<Job?> GetByIdAsync(int id)
        {
           return await _context.Jobs.FindAsync(id);
        }

        // public Task<Job?> UpdateAsync(int id, Job jobModel)
        // {
        //      var existingJob = await _context.Jobs.FindAsync(id);

        //     if (existingJob == null)
        //     {
        //         return null;
        //     }

        //     // existingJob.Title = jobModel.Title;
        //     // existingJob.Content = jobModel.Content;

        //     await _context.SaveChangesAsync();

        //     return existingJob;
        // }





       
    }
}
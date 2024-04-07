using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
          [Route("api/Job")]
    [ApiController]
    public class JobController :ControllerBase
    {
         private readonly ApplicationDBContext _context;
        private readonly IJobRepository _jobRepo ;
      public JobController(ApplicationDBContext context,IJobRepository jobRepo)
      {
        _jobRepo=jobRepo ;
        _context = context;

      }
       [HttpGet]
           public async Task<IActionResult> GetAll(){
            // var users= await _context.Users.ToListAsync();
            var jobs= await _jobRepo.GetAllAsync();
            var jobDto= jobs.Select(s=> s.ToJobDto());
            return Ok(jobs);

           }

    }
}
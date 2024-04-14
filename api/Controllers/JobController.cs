using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Job;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  // [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
          [Route("api/Job")]
    [ApiController]
    public class JobController :ControllerBase
    {
         private readonly ApplicationDBContext _context;
        private readonly IJobRepository _jobRepo ;
          private readonly IUserRepository _userRepo ;
      public JobController(ApplicationDBContext context,IJobRepository jobRepo,IUserRepository userRepo)
      {
        _jobRepo=jobRepo ;
        _userRepo=userRepo;
        _context = context;

      }
       [HttpGet]
           public async Task<IActionResult> GetAll(){
            // var users= await _context.Users.ToListAsync();
            var jobs= await _jobRepo.GetAllAsync();
            var jobDto= jobs.Select(s=> s.ToJobDto());
            return Ok(jobs);

           }
 [HttpGet("{id}")]
            public async Task<IActionResult> GetById([FromRoute ]int id){
            // var users= await _context.Users.ToListAsync();
            var job= await _jobRepo.GetByIdAsync(id);
              if(job==null){
            return NotFound();
            }
            return Ok(job.ToJobDto());

           }
                 [HttpPost("{UserId}")]
            public async Task<IActionResult> Create([FromRoute] int UserId, CreateJobDto jobDto)
{
    if (!await _userRepo.UserExists(UserId))
    {
        return BadRequest("User does not exist");
    }

    var jobModel = jobDto.ToJobFromCreate(UserId);
    
    // Assuming CreateAsync returns a Task and you're not using its result here.
    // You might want to handle errors or check its result.
    await _jobRepo.CreateAsync(jobModel);

    // You should return a proper IActionResult here.
    // For example:
    return CreatedAtAction(nameof(GetById), new { id = jobModel.JobId }, jobModel);
}

          [HttpDelete]
        [Route("{id}")]
        public  async Task<IActionResult> Delete ([FromRoute] int id)
        {
           

            var jobModel = await _jobRepo.DeleteAsync(id);

            if (jobModel == null)
            {
                return NotFound("job doesn't exist ");
            }
          
            return Ok(jobModel) ;
        }

        //       [HttpPut]
        // [Route("{id}")]

  //   public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateJobRequestDto updateDto){

  //    var job = await _jobRepo.UpdateAsync(id, updateDto.ToJobFromUpdate(id));

  //    if (job == null)
  //           {
  //               return NotFound("job not found");
  //           }

  //           return Ok(job.ToJobDto());
  // }


    }
}
 
    


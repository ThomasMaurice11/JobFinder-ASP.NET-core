using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Proposal;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
     [Microsoft.AspNetCore.Mvc.Route("api/proposal")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJobRepository _jobRepo;
        private readonly IProposalRepository _proposalRepo;
      
        public ProposalController(UserManager<AppUser> userManager,
        IJobRepository jobRepo, IProposalRepository proposalRepo)
        {
            _userManager = userManager;
            _jobRepo = jobRepo;
            _proposalRepo = proposalRepo;
         
        }

      

        [HttpPost]
[Authorize]
public async Task<IActionResult> AddProposal([FromBody] AddProposalDto dto)
{
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);
    var job = await _jobRepo.GetByIdAsync(dto.JobId);

    if (job == null) 
        return BadRequest("Job not found");

    var proposalModel = new Proposal
    {
        JobId = dto.JobId,
        SenderId = appUser.Id,
        ReceiverId = job.AppUserId,
        SenderName=dto.SenderName,
        DescribeYourself = dto.DescribeYourself,
        ProposalStatus = "pending" // Assuming 0 means pending status
    };

    await _proposalRepo.CreateAsync(proposalModel);

    if (proposalModel == null)
    {
        return StatusCode(500, "Could not create");
    }
    else
    {
        return Created();
    }
}


[HttpPut("accept")]
[Authorize]
public async Task<IActionResult> AcceptProposal(int proposalId)
{
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);

    var proposal = await _proposalRepo.GetByIdAsync(proposalId, appUser.Id);

    if (proposal == null)
        return NotFound("Proposal not found");

    proposal.ProposalStatus = "accepted";
    await _proposalRepo.UpdateAsync(proposal);

    return Ok("Proposal accepted successfully");
}

[HttpPut("/refuse")]
[Authorize]
public async Task<IActionResult> RefuseProposal(int proposalId)
{
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);

    var proposal = await _proposalRepo.GetByIdAsync(proposalId, appUser.Id);

    if (proposal == null)
        return NotFound("Proposal not found");

    proposal.ProposalStatus = "refused";
    await _proposalRepo.UpdateAsync(proposal);

    return Ok("Proposal accepted successfully");
}



         [HttpGet("receiver")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserProposals()
        {
            // var currentUserId = User.GetUserId();
                           var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);

    

            var proposals = await _proposalRepo.GetByCurrentUserAsync(appUser.Id);
           

            return Ok(proposals);
        }
        [HttpGet("myproposals")]
[Authorize]
public async Task<IActionResult> GetMyProposals()
{
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);

    if (appUser == null)
        return NotFound("User not found");

    var proposals = await _proposalRepo.GetBySenderIdAsync(appUser.Id);

    return Ok(proposals);
}

    }


    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Job
{
    public class JobDto
    {
       
      public int JobId { get; set; }
    public int UserId { get; set; }
    public string JobTitle { get; set; }=string.Empty ;
    public string JobType { get; set; } =string.Empty ;
    public decimal JobBudget { get; set; }
    public DateTime CreationDate { get; set; }
    public string JobDescription { get; set; }=string.Empty ;
    public int NumberOfProposals { get; set; } 
    }
}
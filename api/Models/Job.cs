using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
   [Table("Jobs")]
    public class Job
    {
    // public int JobId { get; set; }
    // public int UserId { get; set; }
    // public string JobTitle { get; set; }=string.Empty ;
    // public string Type { get; set; }=string.Empty ;
    // public decimal JobBudget { get; set; }
    // public string JobDescription { get; set; }=string.Empty ;
    // public User? User { get; set;}


      public int JobId { get; set; }
    public int UserId { get; set; }
    public string JobTitle { get; set; }=string.Empty ;
    public string JobType { get; set; } =string.Empty ;
    public decimal JobBudget { get; set; }
    public DateTime CreationDate { get; set; }
    public string JobDescription { get; set; }=string.Empty ;
    public int NumberOfProposals { get; set; } 

    //  public int IsVerifed { get; set; }=0 ; 
    public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();



 
    }
}
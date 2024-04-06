using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using api.Models;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions )
    {
    }

    public DbSet<User> Users { get; set; }
    // public DbSet<Employer> Employers { get; set; }
    // public DbSet<Job> Jobs { get; set; }
    // public DbSet<JobSeeker> JobSeekers { get; set; }
    // public DbSet<Proposal> Proposals { get; set; }
    // public DbSet<SavedJob> SavedJobs { get; set; }
    // public DbSet<Communication> Communications { get; set; }


    //  protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<SavedJob>().HasNoKey();
    //         modelBuilder.Entity<Job>()
    //     .Property(j => j.JobBudget)
    //     .HasColumnType("decimal(18, 2)"); // Adjust the precision and scale as needed



        
    // }
    


}

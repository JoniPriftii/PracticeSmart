using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practice.Models;


namespace Practice.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Emplyees> Emplyees { get; set; }
        public DbSet<Departments> Departments { get; set; }

    }

}

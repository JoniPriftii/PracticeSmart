using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Practice.Models
{
    public class Emplyees : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Commission { get; set; }
        public int? Salary { get; set; }

        public int? DepartmentsId { get; set; }
        [ForeignKey(nameof(DepartmentsId))]
        public virtual Departments? Departments { get; set; }
        public int? JobsId { get; set; }
        [ForeignKey(nameof(JobsId))]
        public virtual Jobs? Jobs { get; set; }
        public string? ManagerId { get; set; }


    }

}

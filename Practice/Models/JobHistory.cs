using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models
{
    public class JobHistory
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int? JobsId { get; set; }
        public virtual Jobs Jobs { get; set; }
        public string EmplyeesId { get; set; }
        public virtual Emplyees Employees { get; set; }
        public int? DepartmentsId { get; set; }
        public virtual Departments Departments { get; set; }
    }
}

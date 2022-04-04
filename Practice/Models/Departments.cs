
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerId { get; set; }
        [Display(Name = "Location")]
        public int? LocationsId { get; set; }
        public virtual Locations Locations { get; set; }

    }
}

using Practice.Models;
namespace Practice.ViewModel
{
    public class UserViewModel
    {
        public Emplyees User { get; set; }
        public Departments Departament { get; set; }
        public Jobs Job { get; set; }
        public string RoleName { get; set; }    
    }
}

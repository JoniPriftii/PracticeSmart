using Microsoft.AspNetCore.Identity;
using Practice.Models;
namespace Practice.ViewModel
{
    public class UserAndRoleViewModel
    {
        public Emplyees? Employees { get; set; } 
        public IdentityRole Role { get; set; }    
       
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Practice.ViewModel
{
    public class CreateRoleViewModel : IdentityRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}

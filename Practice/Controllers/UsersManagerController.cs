using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Practice.ViewModel;
namespace Practice.Controllers
{
    [AllowAnonymous]
    public class UsersManagerController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<Emplyees> _usersManager;
        private RoleManager<IdentityRole> _roleManager;
        public UsersManagerController(ApplicationDbContext applicationDb, UserManager<Emplyees> usersManager, RoleManager<IdentityRole> roleManager)
        {
            _context = applicationDb;
            _usersManager = usersManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {


            var model = new List<UserAndRoleViewModel>();

            foreach (var user in _usersManager.Users)
            {
                var roleId = _context.UserRoles.FirstOrDefault(u => u.UserId == user.Id)?.RoleId;

                
                var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);
                var userAndRoleManager = new UserAndRoleViewModel
                {
                    Employees = user,
                    Role = role,
                    
                };

                model.Add(userAndRoleManager);


            }
            ViewBag.roleList = _roleManager.Roles;
            return View(model);
        }


        public async Task<IActionResult> sendData(string userid , string roleid)
        {

            var user = await _usersManager.FindByIdAsync(userid);
            var role = await _roleManager.FindByIdAsync(roleid);

            var roles = _usersManager.GetRolesAsync(user).Result.ToArray();

            if (roles != null)
            {
                foreach(var r in roles)
                {
                    await _usersManager.RemoveFromRoleAsync(user, r);
                }

            }
            else
            {

            }

            var result = await _usersManager.AddToRoleAsync(user, role.Name);

            return Ok(role.Name);
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = await _usersManager.GetUserAsync(User);


            UserViewModel userViewModel = new UserViewModel
            {
                User = user,
                Departament = _context.Departments.Where(s => s.Id == user.DepartmentsId).FirstOrDefault(),
                Job = _context.Jobs.Where(s => s.Id == user.JobsId).FirstOrDefault()
            };
            return View(userViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Emplyees.FirstOrDefaultAsync(e => e.Id == id);


            UserViewModel userViewModel = new UserViewModel
            {
                User = user,
                Departament = _context.Departments.Where(s => s.Id == user.DepartmentsId).FirstOrDefault(),
                Job = _context.Jobs.Where(s => s.Id == user.JobsId).FirstOrDefault(),

            };


            return View(userViewModel);
        }


    }
}

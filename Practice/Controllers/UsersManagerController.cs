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

            ViewBag.Context = _context;
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
           

            var result = await _usersManager.AddToRoleAsync(user, role.Name);

            return Ok(role.Name);
        }

        public async Task<IActionResult> ChangeName(string userid, string value)
        {
            var user = await _usersManager.FindByIdAsync(userid);

            user.FirstName = value;
            _context.SaveChanges();

            return Ok();
        }
        public async Task<IActionResult> ChangeSurname(string userid, string value)
        {
            var user = await _usersManager.FindByIdAsync(userid);

            user.LastName = value;
            _context.SaveChanges();

            return Ok();
        }
        public async Task<IActionResult> ChangeEmail(string userid, string value)
        {
            var user = await _usersManager.FindByIdAsync(userid);

            var result =  await _usersManager.SetUserNameAsync(user, value);
            if (result.Succeeded)
                return Ok();
            else
                return NotFound();
            
        }
        public async Task<IActionResult> ChangeCommision(string userid, int value)
        {
            var user = await _usersManager.FindByIdAsync(userid);

            user.Commission = value;
            _context.SaveChanges();

            return Ok();
        }       
        public async Task<IActionResult> ChangeDepartament(string userid , int value)
        {
            var user = await _usersManager.FindByIdAsync(userid);

            user.DepartmentsId = value;
            _context.SaveChanges();
            
            return Ok();
        }
        public async Task<IActionResult> ChangeSalary(string userid, int value)
        {
            var user = await _usersManager.FindByIdAsync(userid);

            user.Salary = value;
            _context.SaveChanges();

            return Ok();
        }


        


        //Admin UserDetils Page 
        public async Task<IActionResult> Details(string id)
        {

            var user = await _usersManager.GetUserAsync(User);
            var jobHistories = _context.JobHistories.Where(s => s.EmplyeesId == user.Id).ToList();
            
            if(id != null)
            {
                user = await _context.Emplyees.FirstOrDefaultAsync(e => e.Id == id);

                jobHistories = _context.JobHistories.Where(s => s.EmplyeesId == id).ToList();                       
            }

            var jobHistoryTitles = new List<JobTitleJHViewModel>();

            foreach (var jobHis in jobHistories)
            {
                var job = _context.Jobs.Where(i => i.Id == jobHis.JobsId).FirstOrDefault();
                string jobTitle = job.JobTitle;

                var temporaryJobTitleJh = new JobTitleJHViewModel
                {
                    jobHistory = jobHis,
                    jobTitle = jobTitle

                };
                jobHistoryTitles.Add(temporaryJobTitleJh);
            }
            ViewBag.JobAndHistory = jobHistoryTitles;

            ViewBag.Departments = _context.Departments.ToList();
            
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

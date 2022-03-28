using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practice.Data.Migrations;
using Practice.Models;
using Practice.ViewModel;


namespace Practice.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Emplyees> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<Emplyees> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                };

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                };
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,

            };
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.FirstName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);

            if (role != null)
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.FirstName);
                }
            }
            return View(model);
        }
    }
}

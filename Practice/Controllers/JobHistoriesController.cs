#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    public class JobHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Emplyees> _userManager;

        public JobHistoriesController(ApplicationDbContext context, UserManager<Emplyees> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: JobHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobHistories.Include(j => j.Departments).Include(j => j.Employees).Include(j => j.Jobs);
            ViewBag.Context = _context;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Context = _context;
            var jobHistory = await _context.JobHistories
                .Include(j => j.Departments)
                .Include(j => j.Employees)
                .Include(j => j.Jobs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobHistory == null)
            {
                return NotFound();
            }

            return View(jobHistory);
        }

        // GET: JobHistories/Create
        public IActionResult Create(string? id)
        {
            ViewBag.CurrentId = null;
            if (id != null)
            {
                ViewBag.CurrentId = id;
            }
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id");
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id");
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id");
            return View();
        }


        public async Task<IActionResult> CreateJobHistories(JobHistory jobHistory)
        {
            var user = new Emplyees();

            if (jobHistory.EmplyeesId == null)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
                jobHistory.EmplyeesId = user.Id;
            }
            else
            {
                user = await _userManager.FindByIdAsync(jobHistory.EmplyeesId);

            }

            jobHistory.DepartmentsId = user.DepartmentsId;
            jobHistory.JobsId = user.JobsId;
            _context.Add(jobHistory);
            await _context.SaveChangesAsync();
            return Ok();

            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", jobHistory.DepartmentsId);
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id", jobHistory.EmplyeesId);
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id", jobHistory.JobsId);

        }

        // GET: JobHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistories.FindAsync(id);

            ViewBag.Jobs = _context.Jobs.ToList();
            ViewBag.Emp = _context.Emplyees.ToList();
            ViewBag.Dep = _context.Departments.ToList();
            if (jobHistory == null)
            {
                return NotFound();
            }
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", jobHistory.DepartmentsId);
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id", jobHistory.EmplyeesId);
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id", jobHistory.JobsId);
            return View(jobHistory);
        }


        public async Task<IActionResult> EditJobHistories(JobHistory jobHistory)
        {
            

            try
            {
                JobHistory jobHisDb = _context.JobHistories.FirstOrDefault(j => j.Id == jobHistory.Id);
                jobHisDb.StartDate = jobHistory.StartDate;
                jobHisDb.EndDate = jobHistory.EndDate;
                jobHisDb.EmplyeesId = jobHistory.EmplyeesId;
                jobHisDb.DepartmentsId = jobHistory.DepartmentsId;
                jobHisDb.JobsId = jobHistory.JobsId;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobHistoryExists(jobHistory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", jobHistory.DepartmentsId);
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id", jobHistory.EmplyeesId);
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id", jobHistory.JobsId);

        }

        // GET: JobHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistories
                .Include(j => j.Departments)
                .Include(j => j.Employees)
                .Include(j => j.Jobs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobHistory == null)
            {
                return NotFound();
            }

            return View(jobHistory);
        }

        // POST: JobHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobHistory = await _context.JobHistories.FindAsync(id);
            _context.JobHistories.Remove(jobHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobHistoryExists(int id)
        {
            return _context.JobHistories.Any(e => e.Id == id);
        }
    }
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public JobHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobHistories.Include(j => j.Departments).Include(j => j.Employees).Include(j => j.Jobs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobHistories/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: JobHistories/Create
        public IActionResult Create()
        {
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id");
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id");
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id");
            return View();
        }

        // POST: JobHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,JobsId,EmplyeesId,DepartmentsId")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", jobHistory.DepartmentsId);
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id", jobHistory.EmplyeesId);
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id", jobHistory.JobsId);
            return View(jobHistory);
        }

        // GET: JobHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistories.FindAsync(id);
            if (jobHistory == null)
            {
                return NotFound();
            }
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", jobHistory.DepartmentsId);
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id", jobHistory.EmplyeesId);
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id", jobHistory.JobsId);
            return View(jobHistory);
        }

        // POST: JobHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,JobsId,EmplyeesId,DepartmentsId")] JobHistory jobHistory)
        {
            if (id != jobHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobHistory);
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", jobHistory.DepartmentsId);
            ViewData["EmplyeesId"] = new SelectList(_context.Emplyees, "Id", "Id", jobHistory.EmplyeesId);
            ViewData["JobsId"] = new SelectList(_context.Jobs, "Id", "Id", jobHistory.JobsId);
            return View(jobHistory);
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

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
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Departments.Include(d => d.Locations);
            ViewData["Context"] = _context;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .Include(d => d.Locations)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewData["Context"] = _context;
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["Manager"] = new SelectList(_context.Emplyees, "Id", "FirstName");
            ViewData["LocationsId"] = new SelectList(_context.Locations, "Id", "LocationAddress");
            return View();
        }


        public async Task<IActionResult> CreateDepartment(Departments departments)
        {

            _context.Add(departments);
            await _context.SaveChangesAsync();
            return Ok();

        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments.FindAsync(id);
            if (departments == null)
            {
                return NotFound();
            }
            ViewBag.Employees = new SelectList(_context.Emplyees , "Id","FirstName" );
            ViewData["LocationsCity"] = new SelectList(_context.Locations, "Id", "City", departments.LocationsId);
            return View(departments);
        }


        public async Task<IActionResult> EditDepartment(Departments departments)
        {
            try
            {
                Departments departamentDb = _context.Departments.FirstOrDefault(d => d.Id == departments.Id);
                departamentDb.ManagerId = departments.ManagerId;
                departamentDb.LocationsId = departments.LocationsId;
                departamentDb.Name = departments.Name;
               
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentsExists(departments.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

            ViewData["LocationsId"] = new SelectList(_context.Locations, "Id", "Id", departments.LocationsId);
            return View(departments);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .Include(d => d.Locations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departments = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(departments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}

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
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Countries.Include(c => c.Regions);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Context = _context;
            var countries = await _context.Countries
                .Include(c => c.Regions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countries == null)
            {
                return NotFound();
            }

            return View(countries);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            ViewData["RegionsId"] = new SelectList(_context.Regions, "Id", "Name");
            return View();
        }


        public async Task<IActionResult> CreateCountries(Countries countries)
        {

            _context.Add(countries);
            await _context.SaveChangesAsync();
            return Ok();
            ViewData["RegionsId"] = new SelectList(_context.Regions, "Id", "Name", countries.RegionsId);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countries = await _context.Countries.FindAsync(id);
            if (countries == null)
            {
                return NotFound();
            }
            ViewData["RegionsName"] = new SelectList(_context.Regions, "Id", "Name", countries.RegionsId);
            return View(countries);
        }


        public async Task<IActionResult> EditCountries( Countries countries)
        {   
            try
            {
                Countries count = await _context.Countries.FindAsync(countries.Id);
                count.Name = countries.Name;
                count.RegionsId = countries.RegionsId;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(countries.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

            ViewData["RegionsId"] = new SelectList(_context.Regions, "Id", "Id", countries.RegionsId);

        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countries = await _context.Countries
                .Include(c => c.Regions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countries == null)
            {
                return NotFound();
            }

            return View(countries);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countries = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(countries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountriesExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}

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
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Locations.Include(l => l.Countries);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Context = _context;
            var locations = await _context.Locations
                .Include(l => l.Countries)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Id");
            return View();
        }


        public async Task<IActionResult> CreateLocations(Locations locations)
        {

            _context.Add(locations);
            await _context.SaveChangesAsync();
            return Ok();

            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Id", locations.CountriesId);

        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations.FindAsync(id);
            if (locations == null)
            {
                return NotFound();
            }
            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Id", locations.CountriesId);
            return View(locations);
        }


        public async Task<IActionResult> EditLocations( Locations locations)
        {            
            try
            {
                Locations loc = _context.Locations.FirstOrDefault(l => l.Id == locations.Id);
                loc.LocationAddress = locations.LocationAddress;
                loc.PostalCode = locations.PostalCode;
                loc.City = locations.City;
                loc.StateProvince = locations.StateProvince;
                loc.CountriesId = locations.CountriesId;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationsExists(locations.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

            ViewData["CountriesId"] = new SelectList(_context.Countries, "Id", "Id", locations.CountriesId);

        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .Include(l => l.Countries)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locations = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(locations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationsExists(int id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}

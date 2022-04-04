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
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regions.ToListAsync());
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regions == null)
            {
                return NotFound();
            }

            return View(regions);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> CreateRegions(Regions regions)
        {

            _context.Add(regions);
            await _context.SaveChangesAsync();
            return Ok();

        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions.FindAsync(id);
            if (regions == null)
            {
                return NotFound();
            }
            return View(regions);
        }


        public async Task<IActionResult> EditRegions( Regions regions)
        {
            try
            {
                Regions reg = _context.Regions.FirstOrDefault(r => r.Id == regions.Id);
                reg.Name = regions.Name;                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionsExists(regions.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();


        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regions == null)
            {
                return NotFound();
            }

            return View(regions);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regions = await _context.Regions.FindAsync(id);
            _context.Regions.Remove(regions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionsExists(int id)
        {
            return _context.Regions.Any(e => e.Id == id);
        }
    }
}

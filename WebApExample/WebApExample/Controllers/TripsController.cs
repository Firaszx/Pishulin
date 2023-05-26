using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApExample.Data;
using WebApExample.Models;

namespace WebApExample.Controllers
{
    public class TripsController : Controller
    {
        private readonly Context _context;

        public TripsController(Context context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
              return _context.Trips != null ? 
                          View(await _context.Trips.ToListAsync()) :
                          Problem("Entity set 'Context.Trips'  is null.");
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trips = await _context.Trips
                .FirstOrDefaultAsync(m => m.TravelID == id);
            if (trips == null)
            {
                return NotFound();
            }

            return View(trips);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelID,Cost,Duration,PasNum")] Trips trips)
        {
           
                _context.Add(trips);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trips = await _context.Trips.FindAsync(id);
            if (trips == null)
            {
                return NotFound();
            }
            return View(trips);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelID,Cost,Duration,PasNum")] Trips trips)
        {
            if (id != trips.TravelID)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(trips);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripsExists(trips.TravelID))
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

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trips == null)
            {
                return NotFound();
            }

            var trips = await _context.Trips
                .FirstOrDefaultAsync(m => m.TravelID == id);
            if (trips == null)
            {
                return NotFound();
            }

            return View(trips);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trips == null)
            {
                return Problem("Entity set 'Context.Trips'  is null.");
            }
            var trips = await _context.Trips.FindAsync(id);
            if (trips != null)
            {
                _context.Trips.Remove(trips);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripsExists(int id)
        {
          return (_context.Trips?.Any(e => e.TravelID == id)).GetValueOrDefault();
        }
    }
}

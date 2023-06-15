using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organization.Models;
using Organization.Models.Data;

namespace Organization.Controllers
{
    public class TradingPointsController : Controller
    {
        private readonly MySuperOrgContext _context;

        public TradingPointsController(MySuperOrgContext context)
        {
            _context = context;
        }

        // GET: TradingPoints
        public async Task<IActionResult> Index()
        {
              return _context.TradingPoints != null ? 
                          View(await _context.TradingPoints.ToListAsync()) :
                          Problem("Entity set 'MySuperOrgContext.TradingPoints'  is null.");
        }

        // GET: TradingPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TradingPoints == null)
            {
                return NotFound();
            }

            var tradingPoint = await _context.TradingPoints
                .FirstOrDefaultAsync(m => m.TPId == id);
            if (tradingPoint == null)
            {
                return NotFound();
            }

            return View(tradingPoint);
        }

        // GET: TradingPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TradingPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TPId,Name,Type,TOId,Address,ManagerFullName,TOName,ProdavecName")] TradingPoint tradingPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tradingPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tradingPoint);
        }

        // GET: TradingPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TradingPoints == null)
            {
                return NotFound();
            }

            var tradingPoint = await _context.TradingPoints.FindAsync(id);
            if (tradingPoint == null)
            {
                return NotFound();
            }
            return View(tradingPoint);
        }

        // POST: TradingPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TPId,Name,Type,TOId,Address,ManagerFullName,TOName,ProdavecName")] TradingPoint tradingPoint)
        {
            if (id != tradingPoint.TPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tradingPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradingPointExists(tradingPoint.TPId))
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
            return View(tradingPoint);
        }

        // GET: TradingPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TradingPoints == null)
            {
                return NotFound();
            }

            var tradingPoint = await _context.TradingPoints
                .FirstOrDefaultAsync(m => m.TPId == id);
            if (tradingPoint == null)
            {
                return NotFound();
            }

            return View(tradingPoint);
        }

        // POST: TradingPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TradingPoints == null)
            {
                return Problem("Entity set 'MySuperOrgContext.TradingPoints'  is null.");
            }
            var tradingPoint = await _context.TradingPoints.FindAsync(id);
            if (tradingPoint != null)
            {
                _context.TradingPoints.Remove(tradingPoint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradingPointExists(int id)
        {
          return (_context.TradingPoints?.Any(e => e.TPId == id)).GetValueOrDefault();
        }
    }
}

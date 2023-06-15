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
    public class TradingOrganizationsController : Controller
    {
        private readonly MySuperOrgContext _context;

        public TradingOrganizationsController(MySuperOrgContext context)
        {
            _context = context;
        }

        // GET: TradingOrganizations
        public async Task<IActionResult> Index()
        {
              return _context.TradingOrganizations != null ? 
                          View(await _context.TradingOrganizations.ToListAsync()) :
                          Problem("Entity set 'MySuperOrgContext.TradingOrganizations'  is null.");
        }

        // GET: TradingOrganizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TradingOrganizations == null)
            {
                return NotFound();
            }

            var tradingOrganization = await _context.TradingOrganizations
                .FirstOrDefaultAsync(m => m.TOId == id);
            if (tradingOrganization == null)
            {
                return NotFound();
            }

            return View(tradingOrganization);
        }

        // GET: TradingOrganizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TradingOrganizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TOId,Name,Address,DirectorFullName,NalogNumber")] TradingOrganization tradingOrganization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tradingOrganization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tradingOrganization);
        }

        // GET: TradingOrganizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TradingOrganizations == null)
            {
                return NotFound();
            }

            var tradingOrganization = await _context.TradingOrganizations.FindAsync(id);
            if (tradingOrganization == null)
            {
                return NotFound();
            }
            return View(tradingOrganization);
        }

        // POST: TradingOrganizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TOId,Name,Address,DirectorFullName,NalogNumber")] TradingOrganization tradingOrganization)
        {
            if (id != tradingOrganization.TOId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tradingOrganization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradingOrganizationExists(tradingOrganization.TOId))
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
            return View(tradingOrganization);
        }

        // GET: TradingOrganizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TradingOrganizations == null)
            {
                return NotFound();
            }

            var tradingOrganization = await _context.TradingOrganizations
                .FirstOrDefaultAsync(m => m.TOId == id);
            if (tradingOrganization == null)
            {
                return NotFound();
            }

            return View(tradingOrganization);
        }

        // POST: TradingOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TradingOrganizations == null)
            {
                return Problem("Entity set 'MySuperOrgContext.TradingOrganizations'  is null.");
            }
            var tradingOrganization = await _context.TradingOrganizations.FindAsync(id);
            if (tradingOrganization != null)
            {
                _context.TradingOrganizations.Remove(tradingOrganization);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradingOrganizationExists(int id)
        {
          return (_context.TradingOrganizations?.Any(e => e.TOId == id)).GetValueOrDefault();
        }
    }
}

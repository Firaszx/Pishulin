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
    public class SupplierOrdersController : Controller
    {
        private readonly MySuperOrgContext _context;

        public SupplierOrdersController(MySuperOrgContext context)
        {
            _context = context;
        }

        // GET: SupplierOrders
        public async Task<IActionResult> Index()
        {
              return _context.SupplierOrders != null ? 
                          View(await _context.SupplierOrders.ToListAsync()) :
                          Problem("Entity set 'MySuperOrgContext.SupplierOrders'  is null.");
        }

        // GET: SupplierOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SupplierOrders == null)
            {
                return NotFound();
            }

            var supplierOrder = await _context.SupplierOrders
                .FirstOrDefaultAsync(m => m.SupOId == id);
            if (supplierOrder == null)
            {
                return NotFound();
            }

            return View(supplierOrder);
        }

        // GET: SupplierOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupOId,OrderDate,ProductName,Quantity,Price,SupName,name")] SupplierOrder supplierOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierOrder);
        }

        // GET: SupplierOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SupplierOrders == null)
            {
                return NotFound();
            }

            var supplierOrder = await _context.SupplierOrders.FindAsync(id);
            if (supplierOrder == null)
            {
                return NotFound();
            }
            return View(supplierOrder);
        }

        // POST: SupplierOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupOId,OrderDate,ProductName,Quantity,Price,SupName,name")] SupplierOrder supplierOrder)
        {
            if (id != supplierOrder.SupOId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierOrderExists(supplierOrder.SupOId))
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
            return View(supplierOrder);
        }

        // GET: SupplierOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SupplierOrders == null)
            {
                return NotFound();
            }

            var supplierOrder = await _context.SupplierOrders
                .FirstOrDefaultAsync(m => m.SupOId == id);
            if (supplierOrder == null)
            {
                return NotFound();
            }

            return View(supplierOrder);
        }

        // POST: SupplierOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SupplierOrders == null)
            {
                return Problem("Entity set 'MySuperOrgContext.SupplierOrders'  is null.");
            }
            var supplierOrder = await _context.SupplierOrders.FindAsync(id);
            if (supplierOrder != null)
            {
                _context.SupplierOrders.Remove(supplierOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierOrderExists(int id)
        {
          return (_context.SupplierOrders?.Any(e => e.SupOId == id)).GetValueOrDefault();
        }
    }
}

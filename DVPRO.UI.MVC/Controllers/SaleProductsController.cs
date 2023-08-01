using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DVPRO.DATA.EF.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace DVPRO.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin, Accounting")]
    public class SaleProductsController : Controller
    {
        private readonly DVPROContext _context;

        public SaleProductsController(DVPROContext context)
        {
            _context = context;
        }

        // GET: SaleProducts
        public async Task<IActionResult> Index()
        {
            var dVPROContext = _context.SaleProducts.Include(s => s.Product).Include(s => s.Sale.Customer) ;
            return View(await dVPROContext.ToListAsync());
        }

        // GET: SaleProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaleProducts == null)
            {
                return NotFound();
            }

            var saleProduct = await _context.SaleProducts
                .Include(s => s.Product)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.SaleProductId == id);
            if (saleProduct == null)
            {
                return NotFound();
            }

            return View(saleProduct);
        }

        // GET: SaleProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["SaleId"] = new SelectList(_context.Sales.Include(e => e.Customer), "SaleId", "SaleProdSum");
            return View();
        }

        // POST: SaleProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleProductId,SaleId,ProductId,SaleQuantity, SaleProdSum")] SaleProduct saleProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", saleProduct.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sales.Include(e => e.Customer), "SaleId", "SaleProdSum", saleProduct.SaleId);
            return View(saleProduct);
        }

        // GET: SaleProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaleProducts == null)
            {
                return NotFound();
            }

            var saleProduct = await _context.SaleProducts.FindAsync(id);
            if (saleProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", saleProduct.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sales.Include(e => e.Customer), "SaleId", "SaleProdSum", saleProduct.SaleId);
            return View(saleProduct);
        }

        // POST: SaleProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleProductId,SaleId,ProductId,SaleQuantity, SaleProdSum")] SaleProduct saleProduct)
        {
            if (id != saleProduct.SaleProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleProductExists(saleProduct.SaleProductId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", saleProduct.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sales.Include(e => e.Customer), "SaleId", "SaleProdSum", saleProduct.SaleId);
            return View(saleProduct);
        }

        // GET: SaleProducts/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaleProducts == null)
            {
                return NotFound();
            }

            var saleProduct = await _context.SaleProducts
                .Include(s => s.Product)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.SaleProductId == id);
            if (saleProduct == null)
            {
                return NotFound();
            }

            return View(saleProduct);
        }

        // POST: SaleProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaleProducts == null)
            {
                return Problem("Entity set 'DVPROContext.SaleProducts'  is null.");
            }
            var saleProduct = await _context.SaleProducts.FindAsync(id);
            if (saleProduct != null)
            {
                _context.SaleProducts.Remove(saleProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleProductExists(int id)
        {
          return (_context.SaleProducts?.Any(e => e.SaleProductId == id)).GetValueOrDefault();
        }
    }
}

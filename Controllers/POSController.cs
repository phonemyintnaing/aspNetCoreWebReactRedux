using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InitCMS.Data;
using InitCMS.Models;

namespace InitCMS.Controllers
{
    public class POSController : Controller
    {
        private readonly InitCMSContext _context;

        public POSController(InitCMSContext context)
        {
            _context = context;
        }

        // GET: POS
        public async Task<IActionResult> Index()
        {
            var initCMSContext = _context.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.ProductCategory).Include(p => p.Unit).Include(p => p.Variant);
            return View(await initCMSContext.ToListAsync());
        }

        // GET: POS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductCategory)
                .Include(p => p.Unit)
                .Include(p => p.Variant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: POS/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id");
            ViewData["CategoryCatId"] = new SelectList(_context.Category, "CatId", "CatId");
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategory, "Id", "Id");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id");
            ViewData["VariantId"] = new SelectList(_context.Variants, "Id", "Id");
            return View();
        }

        // POST: POS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PCode,Description,LongDesc,PurchasePrice,SellPrice,InStock,Sale,CreatedDate,ProductCategoryID,CategoryCatId,ImagePath,IsSelected,BrandId,UnitId,VariantId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            ViewData["CategoryCatId"] = new SelectList(_context.Category, "CatId", "CatId", product.CategoryCatId);
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategory, "Id", "Id", product.ProductCategoryID);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
            ViewData["VariantId"] = new SelectList(_context.Variants, "Id", "Id", product.VariantId);
            return View(product);
        }

        // GET: POS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            ViewData["CategoryCatId"] = new SelectList(_context.Category, "CatId", "CatId", product.CategoryCatId);
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategory, "Id", "Id", product.ProductCategoryID);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
            ViewData["VariantId"] = new SelectList(_context.Variants, "Id", "Id", product.VariantId);
            return View(product);
        }

        // POST: POS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PCode,Description,LongDesc,PurchasePrice,SellPrice,InStock,Sale,CreatedDate,ProductCategoryID,CategoryCatId,ImagePath,IsSelected,BrandId,UnitId,VariantId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            ViewData["CategoryCatId"] = new SelectList(_context.Category, "CatId", "CatId", product.CategoryCatId);
            ViewData["ProductCategoryID"] = new SelectList(_context.ProductCategory, "Id", "Id", product.ProductCategoryID);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
            ViewData["VariantId"] = new SelectList(_context.Variants, "Id", "Id", product.VariantId);
            return View(product);
        }

        // GET: POS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductCategory)
                .Include(p => p.Unit)
                .Include(p => p.Variant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: POS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRoom.Data;
using MvcRoom.Models;

namespace MvcRoom.Controllers
{
    public class ProductCategoryListsController : Controller
    {
        private readonly MvcRoomContext _context;

        public ProductCategoryListsController(MvcRoomContext context)
        {
            _context = context;
        }

        // GET: ProductCategoryLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCategoryList.ToListAsync());
        }

        // GET: ProductCategoryLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryList = await _context.ProductCategoryList
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (productCategoryList == null)
            {
                return NotFound();
            }

            return View(productCategoryList);
        }

        // GET: ProductCategoryLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategoryLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatId,Name,CreatedDate,Description,Org_InStock,Update_InStock")] ProductCategoryList productCategoryList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCategoryList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCategoryList);
        }

        // GET: ProductCategoryLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryList = await _context.ProductCategoryList.FindAsync(id);
            if (productCategoryList == null)
            {
                return NotFound();
            }
            return View(productCategoryList);
        }

        // POST: ProductCategoryLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatId,Name,CreatedDate,Description,Org_InStock,Update_InStock")] ProductCategoryList productCategoryList)
        {
            if (id != productCategoryList.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategoryList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryListExists(productCategoryList.CatId))
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
            return View(productCategoryList);
        }

        // GET: ProductCategoryLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryList = await _context.ProductCategoryList
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (productCategoryList == null)
            {
                return NotFound();
            }

            return View(productCategoryList);
        }

        // POST: ProductCategoryLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCategoryList = await _context.ProductCategoryList.FindAsync(id);
            _context.ProductCategoryList.Remove(productCategoryList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryListExists(int id)
        {
            return _context.ProductCategoryList.Any(e => e.CatId == id);
        }
    }
}

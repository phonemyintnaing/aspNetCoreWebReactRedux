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
    public class POStatusController : Controller
    {
        private readonly InitCMSContext _context;

        public POStatusController(InitCMSContext context)
        {
            _context = context;
        }

        // GET: POStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.POStatuses.ToListAsync());
        }

        // GET: POStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOStatus = await _context.POStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pOStatus == null)
            {
                return NotFound();
            }

            return View(pOStatus);
        }

        // GET: POStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: POStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] POStatus pOStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pOStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pOStatus);
        }

        // GET: POStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOStatus = await _context.POStatuses.FindAsync(id);
            if (pOStatus == null)
            {
                return NotFound();
            }
            return View(pOStatus);
        }

        // POST: POStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] POStatus pOStatus)
        {
            if (id != pOStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pOStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POStatusExists(pOStatus.Id))
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
            return View(pOStatus);
        }

        // GET: POStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOStatus = await _context.POStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pOStatus == null)
            {
                return NotFound();
            }

            return View(pOStatus);
        }

        // POST: POStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pOStatus = await _context.POStatuses.FindAsync(id);
            _context.POStatuses.Remove(pOStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POStatusExists(int id)
        {
            return _context.POStatuses.Any(e => e.Id == id);
        }
    }
}

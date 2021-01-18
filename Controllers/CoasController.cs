using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InitCMS.Data;
using InitCMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace InitCMS.Component
{
    public class CoasController : Controller
    {
        private readonly InitCMSContext _context;

        public CoasController(InitCMSContext context)
        {
            _context = context;
        }

        // GET: Coas
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");

            }
            var initCMSContext = _context.Coa.Include(c => c.CoaType);
            return View(await initCMSContext.ToListAsync());
        }

        // GET: Coas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");

            }
            if (id == null)
            {
                return NotFound();
            }

            var coa = await _context.Coa
                .Include(c => c.CoaType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coa == null)
            {
                return NotFound();
            }

            return View(coa);
        }
        //Remote Validation for Product Code
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckCCode(string code)
        {

            var query = await _context.Coa.FirstOrDefaultAsync(c => c.Code == code);

            if (query == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"This Code {code} is already in use. Please Choose Different Code!");
            }

        }

        // GET: Coas/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewData["CoaTypeId"] = new SelectList(_context.CoaType, "Id", "Description");
            return View();
        }

        // POST: Coas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description,CoaTypeId")] Coa coa)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                _context.Add(coa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoaTypeId"] = new SelectList(_context.CoaType, "Id", "Description", coa.CoaTypeId);
            return View(coa);
        }

        // GET: Coas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }

            if (id == null)
            {
                return NotFound();
            }

            var coa = await _context.Coa.FindAsync(id);
            if (coa == null)
            {
                return NotFound();
            }
            ViewData["CoaTypeId"] = new SelectList(_context.CoaType, "Id", "Description", coa.CoaTypeId);
            return View(coa);
        }

        // POST: Coas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Description,CoaTypeId")] Coa coa)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }

            if (id != coa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoaExists(coa.Id))
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
            ViewData["CoaTypeId"] = new SelectList(_context.CoaType, "Id", "Description", coa.CoaTypeId);
            return View(coa);
        }

        // GET: Coas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return NotFound();
            }

            var coa = await _context.Coa
                .Include(c => c.CoaType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coa == null)
            {
                return NotFound();
            }

            return View(coa);
        }

        // POST: Coas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coa = await _context.Coa.FindAsync(id);
            _context.Coa.Remove(coa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoaExists(int id)
        {
            return _context.Coa.Any(e => e.Id == id);
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InitCMS.Data;
using InitCMS.Models;
using InitCMS.ViewModel;
using System;
using Microsoft.AspNetCore.Http;

namespace InitCMS.Controllers
{
    public class ExpenseEntriesController : Controller
    {
        private readonly InitCMSContext _context;

        public ExpenseEntriesController(InitCMSContext context)
        {
            _context = context;
        }

        // GET: ExpenseEntries1
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }

            DateTime dateValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Myanmar Standard Time")); //for converting to IST
            DateTime startDateTime = dateValue; //Today at 00:00:00
            //DateTime endDateTime = dateValue.AddDays(1).AddTicks(-1); //Today at 23:59:59

            //var initCMSContext = _context.ExpenseEntry.Where(d => d.CreatedDate >= startDateTime && d.CreatedDate <= endDateTime).Include(e => e.Coa).Include(e => e.User);
            var initCMSContext = _context.ExpenseEntry.Where(d => d.CreatedDate.Date == startDateTime.Date).Include(e => e.Coa).Include(e => e.User);
            return View(await initCMSContext.ToListAsync());
        }
        public IActionResult ReportView()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");

            }
            return View();
        }
        public async Task<IActionResult> Report(ReportViewVewModel rv)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            DateTime startDateTime = rv.StartDate.Date; //new DateTime(2021,01,01);//; //Today at 00:00:00
            DateTime endDateTime = rv.EndDate.Date.AddDays(1).AddTicks(-1); //Today at 23:59:59

            var initCMSContext = _context.ExpenseEntry.Where(d => d.CreatedDate >= startDateTime && d.CreatedDate <= endDateTime).Include(e => e.Coa).Include(e => e.User);
            return View(await initCMSContext.ToListAsync());
        }

        // GET: ExpenseEntries1/Details/5
        /**
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseEntry = await _context.ExpenseEntry
                .Include(e => e.Coa)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseEntry == null)
            {
                return NotFound();
            }

            return View(expenseEntry);
        }
        **/

        // GET: ExpenseEntries1/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }

            ViewData["CoaId"] = new SelectList(_context.Coa, "Id", "Description");
            return View();
        }

        // POST: ExpenseEntries1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoaId,Amount,Notes,CreatedDate,UserId")] ExpenseEntry expenseEntry)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            //Get Session
            var sessionEmail = HttpContext.Session.GetString("SessionEmail").ToLower();
            //Retrieve data
            var userId = await _context.User.Where(e => e.UserEmail.ToLower() == sessionEmail).Select(x => x.Id).FirstOrDefaultAsync();
            
            if (ModelState.IsValid)
            {
                var ee = new ExpenseEntry()
                {
                    CoaId = expenseEntry.CoaId,
                    Amount = expenseEntry.Amount,
                    Notes = expenseEntry.Notes,
                    CreatedDate = expenseEntry.CreatedDate,
                    UserId = userId
                };
                _context.Add(ee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoaId"] = new SelectList(_context.Coa, "Id", "Description", expenseEntry.CoaId);
           
            return View(expenseEntry);
        }

        // GET: ExpenseEntries1/Edit/5
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

            var expenseEntry = await _context.ExpenseEntry.FindAsync(id);
            if (expenseEntry == null)
            {
                return NotFound();
            }
            ViewData["CoaId"] = new SelectList(_context.Coa, "Id", "Description", expenseEntry.CoaId);
            
            return View(expenseEntry);
        }

        // POST: ExpenseEntries1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoaId,Amount,Notes,CreatedDate")] ExpenseEntry expenseEntry)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            if (id != expenseEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Get Session
                    var sessionEmail = HttpContext.Session.GetString("SessionEmail").ToLower();
                    //Retrieve data
                    var userId = await _context.User.Where(e => e.UserEmail.ToLower() == sessionEmail).Select(x => x.Id).FirstOrDefaultAsync();
                    
                    var ee = new ExpenseEntry()
                    {   
                        Id  = expenseEntry.Id,
                        CoaId = expenseEntry.CoaId,
                        Amount = expenseEntry.Amount,
                        Notes = expenseEntry.Notes,
                        CreatedDate = expenseEntry.CreatedDate,
                        UserId = userId
                    };
                    _context.Update(ee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseEntryExists(expenseEntry.Id))
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
            ViewData["CoaId"] = new SelectList(_context.Coa, "Id", "Description", expenseEntry.CoaId);

            return View(expenseEntry);
        }

        // GET: ExpenseEntries1/Delete/5
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

            var expenseEntry = await _context.ExpenseEntry
                .Include(e => e.Coa)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseEntry == null)
            {
                return NotFound();
            }

            return View(expenseEntry);
        }

        // POST: ExpenseEntries1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseEntry = await _context.ExpenseEntry.FindAsync(id);
            _context.ExpenseEntry.Remove(expenseEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseEntryExists(int id)
        {
            return _context.ExpenseEntry.Any(e => e.Id == id);
        }
    }
}

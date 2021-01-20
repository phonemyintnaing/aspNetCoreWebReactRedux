using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InitCMS.Data;
using InitCMS.ViewModel;
using InitCMS.Models;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace InitCMS.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly InitCMSContext _context;

        public PurchaseOrderController(InitCMSContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrder
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");

            }
            DateTime startDateTime = DateTime.Today; //Today at 00:00:00
            DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59

            var initCMSContext = _context.POViewModels.Where(d => d.PODate >= startDateTime && d.PODate <= endDateTime).Include(p => p.Product).Include(p => p.Store).Include(p => p.POStatus).Include(p => p.Supplier).Include(u=> u.User);
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

            var initCMSContext = _context.POViewModels.Where(d => d.PODate >= startDateTime && d.PODate <= endDateTime).Include(p => p.Product).Include(p => p.Store).Include(p => p.POStatus).Include(p => p.Supplier).Include(u => u.User);
            return View(await initCMSContext.ToListAsync());
        }

        // GET: PurchaseOrder/Details/5
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

            var pOViewModel = await _context.POViewModels
                .Include(p => p.Product)
                .Include(p => p.Store)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pOViewModel == null)
            {
                return NotFound();
            }

            return View(pOViewModel);
        }

        // GET: PurchaseOrder/Create
        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Title");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            ViewData["POStatusId"] = new SelectList(_context.POStatuses, "Id", "Title");
            return View();
        }

        // POST: PurchaseOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RefNumber,SupplierId,ProductId,StoreId,Quantity,Cost,Discount,TotalCost,POStatusId,Note,PODate,UserId")] POViewModel pOViewModel)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "Admin");
            }

            if (ModelState.IsValid)
            {
                using var transaction = _context.Database.BeginTransaction();
               
                try
                {
                    //Get Session
                    var sessionEmail = HttpContext.Session.GetString("SessionEmail").ToLower();
                    //Retrieve data
                    var getUerId = await _context.User.Where(e => e.UserEmail.ToLower() == sessionEmail).Select(x => x.Id).FirstOrDefaultAsync();

                    var po = new POViewModel {
                        RefNumber = pOViewModel.RefNumber,
                        SupplierId = pOViewModel.SupplierId,
                        ProductId = pOViewModel.ProductId,
                        StoreId = pOViewModel.StoreId,
                        Quantity = pOViewModel.Quantity,
                        Cost = pOViewModel.Cost,
                        Discount = pOViewModel.Discount,
                        TotalCost = pOViewModel.TotalCost,
                        POStatusId = pOViewModel.POStatusId,
                        Note = pOViewModel.Note,
                        PODate = DateTime.Now,
                        UserId = getUerId                    
                    };

                    _context.Add(po);
                    await _context.SaveChangesAsync();

                    //Insert into Stock
                    var stocks = new Stock
                    {
                        POId = pOViewModel.Id,
                        ProductId = pOViewModel.ProductId,
                        Quantity = pOViewModel.Quantity,
                        StockDate = DateTime.Now,
                        StockInStatus = 2, //POS 1, PO 2, StockAdjustment 3
                        UserId = getUerId //pOViewModel.UserId
                    };
                    _context.Add(stocks);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    
                    return RedirectToAction(nameof(Index));
                    
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return NotFound();
                }
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", pOViewModel.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Title", pOViewModel.StoreId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", pOViewModel.SupplierId);
            ViewData["POStatusId"] = new SelectList(_context.POStatuses, "Id", "Title", pOViewModel.POStatusId);
            return View(pOViewModel);

        }

        //// GET: PurchaseOrder/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
        //    {
        //        return RedirectToAction("Login", "Admin");

        //    }
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pOViewModel = await _context.POViewModels.FindAsync(id);
        //    if (pOViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", pOViewModel.ProductId);
        //    ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Id", pOViewModel.StoreId);
        //    ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Id", pOViewModel.SupplierId);
        //    return View(pOViewModel);
        //}

        //// POST: PurchaseOrder/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,RefNumber,SupplierId,ProductId,StoreId,Quantity,Cost,Discount,TotalCost,POStatusId,Note,PODate,UserId")] POViewModel pOViewModel)
        //{
        //    if (id != pOViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pOViewModel);
        //            await _context.SaveChangesAsync();
        //            //Insert into Stock
        //            var stocks = new Stock
        //            {
        //                POId = pOViewModel.Id,
        //                ProductId = pOViewModel.ProductId,
        //                Quantity = pOViewModel.Quantity,
        //                StockDate = DateTime.Now,
        //                StockInStatus = 3, //POS 1, PO 2, StockAdjustment 3
        //                UserId = 1 //pOViewModel.UserId
        //            };
        //            _context.Update(stocks);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!POViewModelExists(pOViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", pOViewModel.ProductId);
        //    ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Id", pOViewModel.StoreId);
        //    ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Id", pOViewModel.SupplierId);
        //    return View(pOViewModel);
        //}

        //// GET: PurchaseOrder/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
        //    {
        //        return RedirectToAction("Login", "Admin");

        //    }
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pOViewModel = await _context.POViewModels
        //        .Include(p => p.Product)
        //        .Include(p => p.Store)
        //        .Include(p => p.Supplier)
        //        .Include(p => p.POStatus)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pOViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pOViewModel);
        //}

        //// POST: PurchaseOrder/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pOViewModel = await _context.POViewModels.FindAsync(id);
        //    _context.POViewModels.Remove(pOViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool POViewModelExists(int id)
        {
            return _context.POViewModels.Any(e => e.Id == id);
        }
    }
}

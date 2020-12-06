using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitCMS.Data;
using InitCMS.ViewModel;
using InitCMS.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "POSLogin");

            }
            var initCMSContext = _context.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.ProductCategory).Include(p => p.Unit).Include(p => p.Variant);
            ViewData["Customer"] = new SelectList(_context.Customers, "Id", "Name");
            ViewData["Store"] = new SelectList(_context.Stores, "Id", "Title");
            return View(await initCMSContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> BillPay([FromBody]ReceiptSaleViewModel model)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionEmail")))
            {
                return RedirectToAction("Login", "POSLogin");

            }
            using var transaction = _context.Database.BeginTransaction();
           
            try
            {
                //Get Session
                var sessionEmail = HttpContext.Session.GetString("SessionEmail").ToLower();
                //Retrieve data
                var getUerId = await _context.User.Where(e => e.UserEmail.ToLower() == sessionEmail).Select(x => x.Id).FirstOrDefaultAsync();

                _context.Receipts.Add(model.Receipt);
                await _context.SaveChangesAsync();

                foreach (var item in model.Sale)
                {

                     item.ReceiptId = model.Receipt.Id;
                     _context.Sales.Add(item);                  

                    ////Insert into Stock
                    var stocks = new Stock
                    {

                        ProductId = item.ProductId,
                        Quantity = -item.Quantity,
                        StockDate = DateTime.Now,
                        StockInStatus = 1, //POS 1, PO 2, StockAdjustment 3
                        UserId = getUerId
                    };
                    _context.Stocks.Add(stocks);
                   await _context.SaveChangesAsync();

                }
                await _context.SaveChangesAsync();
                transaction.Commit();

                return Json(model.Receipt.Id);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return Json("fail");
            }

        }

    }
}

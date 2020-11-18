using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitCMS.Data;
using InitCMS.ViewModel;
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

        [HttpPost]
        public IActionResult BillPay([FromBody]ReceiptSaleViewModel model)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
               _context.Receipts.Add(model.Receipt);
               _context.SaveChanges();
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
                        UserId = 1
                    };
                    _context.Stocks.Add(stocks);
                    _context.SaveChanges();

                }
                _context.SaveChanges();
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

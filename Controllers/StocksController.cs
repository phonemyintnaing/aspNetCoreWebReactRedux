using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitCMS.Data;
using InitCMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using InitCMS.ViewModel;
using Microsoft.AspNetCore.Http;

namespace InitCMS.Controllers
{
    public class StocksController : Controller
    {
        private readonly InitCMSContext _context;

        public StocksController(InitCMSContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var query = from b in _context.Stocks
                        join p in _context.Products
                            on b.ProductId equals p.Id
                        select new { p.Name, b.Quantity } into x
                        group x by new { x.Name } into g
                        select ( new StockProductViewModel
                        {
                            ProductName = g.Key.Name,                           
                            Quantity = g.Sum(x => x.Quantity)
                        });
            
            return View(await query.ToListAsync());
        }


        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,POId,ProductId,Quantity,StockDate,StockInStatus,UserId")] Stock stock)
        {
            //Get Session
            var sessionEmail = HttpContext.Session.GetString("SessionEmail").ToLower();
            //Retrieve data
            var getUerId = await _context.User.Where(e => e.UserEmail.ToLower() == sessionEmail).Select(x => x.UserId).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                var stocks = new Stock
                {
                    ProductId = stock.ProductId,
                    Quantity = stock.Quantity,
                    StockDate = System.DateTime.Now,
                    StockInStatus = 3, //POS 1, PO 2, StockAdjustment 3
                    UserId = getUerId
                };
                _context.Add(stocks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        private bool StockExists(int id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }
    }
    //Extension Class
   

}

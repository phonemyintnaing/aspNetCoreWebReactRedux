using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InitCMS.Models;
using InitCMS.Data;
using System.Collections.Generic;
using System.Linq;
using InitCMS.ViewModel;

namespace InitCMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InitCMSContext _context;
        public HomeController(ILogger<HomeController> logger, InitCMSContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var ProductCount = (from row in _context.Products
                          select row).Count();
            var PCCount = (from row in _context.ProductCategory
                                select row).Count();
            ViewBag.PCount = ProductCount;
            ViewBag.PCCount = PCCount;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

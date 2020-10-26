using InitCMS.Data;
using InitCMS.Migrations;
using InitCMS.Models;
using InitCMS.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InitCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayBill : ControllerBase
    {
        private readonly InitCMSContext _context;
        //private readonly Sale _sale;
        public PayBill(InitCMSContext context)
        {
            _context = context;
            //_sale = sale;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.Sales.ToList());
        }
        // POST api/<PayBill>
        //[HttpPost]
        //public ActionResult Post([FromBody] ReceiptSaleViewModel model)
        //{
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
                    
        //            _context.Receipts.Add(model.Receipt);
        //           // var sale = new List<Sale>();
        //            foreach (var item in sale)
        //            {
        //                item.ReceiptId = receipt.Id;
        //                _context.Sales.Add(item);

        //            }
        //            _context.SaveChanges();
        //            transaction.Commit();

        //            return Ok(StatusCodes.Status200OK);
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //            return NotFound();
        //        }

        //    }
        //}

    }
}

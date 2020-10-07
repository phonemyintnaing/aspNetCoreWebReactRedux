using InitCMS.Data;
using InitCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InitCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayBill : ControllerBase
    {
        private readonly InitCMSContext _context;
        public PayBill (InitCMSContext context)
        {
            _context = context;
        }
        // POST api/<PayBill>
        [HttpPost]
        public IActionResult Post([FromBody] Sale model)
        {
            try
            {
                _context.Sales.Add(model);
                _context.SaveChanges();
            //    var message = Request.Create(HttpStatusCode.Created, model);
                return Ok(StatusCodes.Status200OK);
            }
            catch(Exception)
            {
                throw;
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tier2.Data;
using Tier2.Models;
using Tier2.Models.BookSale;
using Tier2.Network;

namespace Tier2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {
        private ISaleService saleService;

        public SalesController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

/*      [HttpGet]
        //<-- Remember to add something like public async Task<ActionResult<User>> ValidateUser([FromQuery] string UserName, string Password) to get a specific BookSale
        public async Task<ActionResult<string>> GetBookSale()
        {
            try
            {
                string bookSale = await _network.GetSaleAsync();
                return Ok(bookSale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<string>> GetAllBookSales()
        {            
            Console.WriteLine("TESTController");
            try
            {
                string bookSales = await _network.GetAllBookSalesAsync();
                Console.WriteLine("Test: " + bookSales);

                return Ok(bookSales);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
*/
        [HttpGet]
        public async Task<ActionResult<IList<BookSale>>> GetAllBookSalesAsync([FromQuery] int? bookSaleId)
        {
            
            try
            {
                IList<BookSale> bookSales = await saleService.GetAllBookSalesAsync();
                for (int i = 0; i < bookSales.Count; i++)
                {
                    Console.WriteLine(bookSales[i].bookSaleID);
                }
                return Ok(bookSales);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<BookSale>> CreateBookSaleAsync([FromBody] BookSale bookSale)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            try
            {
                BookSale addedBookSale = await saleService.CreateBookSaleAsync(bookSale);
                Console.WriteLine("IM IN THE HOLE CONTROLLER");
                return Created($"/{addedBookSale.title}",addedBookSale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
           
        }

        [HttpPatch]
        [Route("{bookSaleId:int}")]
        public async Task<ActionResult> UpdateBookSale([FromBody] BookSale bookSale) {
            try {
                await saleService.UpdateAsync(bookSale);
                return Ok(bookSale);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteBookSale([FromRoute] int id) {
            try {
                await saleService.RemoveSaleAsync(id);
                return Ok();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
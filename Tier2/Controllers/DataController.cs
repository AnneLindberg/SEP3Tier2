using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tier2.Data;
using Tier2.Network;

namespace Tier2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ISaleService _network;

        public DataController(ISaleService network)
        {
            _network = network;
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
*/

        [HttpGet]
        public async Task<ActionResult<string>> GetAllBookSales()
        {
            try
            {
                string bookSales = await _network.GetAllBookSalesAsync();
                Console.WriteLine(bookSales);
                return Ok(bookSales);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddBookSale([FromBody] string helloworld)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                await _network.AddSaleAsync(helloworld);
                return Ok(helloworld);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
           
        }
    }
}
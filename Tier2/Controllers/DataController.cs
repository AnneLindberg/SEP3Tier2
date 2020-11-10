using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3_Tier1.Models;
using Tier2.Network;
using WebAPI.Data;

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

        [HttpGet]
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

        [HttpPost]
        public async Task<ActionResult<string>> AddBookSale([FromBody] string helloworld)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try
            {
                Console.WriteLine(helloworld);
                string added = await _network.AddSaleAsync(helloworld);
                return Created($"/{added}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
           
        }
    }
}
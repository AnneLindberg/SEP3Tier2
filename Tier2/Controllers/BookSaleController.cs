using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3_Tier1.Models;
using Tier2.Network;

namespace Tier2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookSaleController : ControllerBase
    {
        private readonly IBookSaleNetwork _network;

        public BookSaleController(IBookSaleNetwork network)
        {
            _network = network;
        }

        [HttpGet]
        public async Task<ActionResult<@string>> GetBookSale([FromQuery] string title)
        {
            var bookSale = _network.GetBookSale(title);
            return Ok(bookSale);
        }

        [HttpPost]
        public async Task<ActionResult<@string>> AddBookSale([FromBody] string helloworld)
        {
            _network.UpdateBookSale(helloworld);
            return Ok(helloworld);
        }
    }
}
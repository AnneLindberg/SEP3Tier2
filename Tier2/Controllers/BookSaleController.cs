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

        private IBookSaleNetwork _network;

        public BookSaleController(IBookSaleNetwork network)
        {
            _network = network;
        }

        [HttpGet]
        public async Task<ActionResult<BookSale>> GetBookSale([FromQuery] string title)
        {
            BookSale bookSale = _network.GetBookSale(title);
            return Ok(bookSale);
        }
        
        [HttpPost]
        public async Task<ActionResult<BookSale>> AddBookSale([FromBody] BookSale bookSale)
        {
            _network.UpdateBookSale(bookSale);
            return Ok(bookSale);
        }
    }
}
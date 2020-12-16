using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Data.Network;
using Tier2.Models;

namespace Tier2.Data.Sale
{
    public class SaleService : ISaleService
    {
        private readonly INetwork DBConn;
        //private string saleToSend;
        //private IList<BookSale> bookSales;
        public SaleService() {
            DBConn = new NetworkSocket();
        }

        public async Task<IList<BookSale>> GetBookSaleAsync(string username)
        {
            return await DBConn.GetBookSaleAsync(username);
        }
        
        public async Task<BookSale> CreateBookSaleAsync(BookSale bookSale) 
        {
            DBConn.CreateBookSale(bookSale);

            return bookSale;
        }
        
        public async Task RemoveBookSaleAsync(int id) {
            DBConn.DeleteBookSale(id);
            
        }
        
        public async Task UpdateBookSaleAsync(BookSale sale) {
            DBConn.UpdateBookSale(sale);

        }
    }
}
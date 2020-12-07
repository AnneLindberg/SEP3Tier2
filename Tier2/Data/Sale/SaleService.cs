using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.BookSale;
using Tier2.Network;

namespace Tier2.Data
{
    public class SaleService : ISaleService
    {
        private readonly INetwork DBConn;
        private string saleToSend;
        private IList<BookSale> bookSales;
        public SaleService() {
            DBConn = new NetworkSocket();
        }

        public async Task<IList<BookSale>> GetBookSaleAsync(string username)
        {
            return await DBConn.GetBookSaleAsync(username);
        }

        public async Task<string> GetSalesAsync() { 
            saleToSend = DBConn.GetBookSale();
            return '"' + saleToSend + '"';
        }
        public async Task<BookSale> CreateBookSaleAsync(BookSale bookSale) 
        {
            DBConn.CreateBookSale(bookSale);

            return bookSale;
        }
        
        public async Task RemoveSaleAsync(int id) {
            DBConn.DeleteBookSale(id);
            
        }
        
        public async Task UpdateAsync(BookSale sale) {
            DBConn.UpdateBookSale(sale);

        }
    }
}
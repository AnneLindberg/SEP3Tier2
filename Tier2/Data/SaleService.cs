using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

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

        public async Task<IList<BookSale>> GetAllBookSalesAsync()
        {
            // Console.WriteLine("????????????????????");
            return await DBConn.GetAllBookSalesAsync();
        }

        public async Task<string> GetSaleAsync() { 
            saleToSend = DBConn.GetBookSale();
            Console.WriteLine(saleToSend);
            return '"' + saleToSend + '"';
        }
        public async Task AddSaleAsync(string sale) {
            DBConn.UpdateBookSale(sale);

        }
        public async Task RemoveSaleAsync(string sale) {
            throw new NotImplementedException("RemoveSaleAsync");
        }
        public async Task<string> UpdateAsync(string sale) {
            throw new NotImplementedException("UpdateAsync");
        }
    }
}
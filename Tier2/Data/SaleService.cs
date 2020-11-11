using System;
using System.Threading.Tasks;
using Tier2.Network;

namespace Tier2.Data
{
    public class SaleService : ISaleService
    {
        private readonly INetwork DBConn;
        private string saleToSend;
        public SaleService() {
            DBConn = new NetworkSocket();
            
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
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace Tier2.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<IList<BookSale>> GetAllBookSalesAsync();
        Task<string> GetSalesAsync();
        Task<BookSaleNoID> CreateBookSaleAsync(BookSaleNoID bookSale);
        Task RemoveSaleAsync(int id);
        Task<string> UpdateAsync(string sale);
    }
}
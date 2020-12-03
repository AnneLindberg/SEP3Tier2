using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.BookSale;

namespace Tier2.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<IList<BookSale>> GetAllBookSalesAsync();
        Task<string> GetSalesAsync();
        Task<BookSale> CreateBookSaleAsync(BookSale bookSale);
        Task RemoveSaleAsync(int id);
        Task<string> UpdateAsync(string sale);
    }
}
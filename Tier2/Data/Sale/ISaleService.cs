using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace Tier2.Data.Sale
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<IList<BookSale>> GetBookSaleAsync(string username);
        Task<BookSale> CreateBookSaleAsync(BookSale bookSale);
        Task RemoveBookSaleAsync(int id);
        Task UpdateBookSaleAsync(BookSale sale);
    }
}
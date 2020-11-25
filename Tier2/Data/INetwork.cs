

using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.Users;

namespace Tier2.Data
{
    public interface INetwork
    {
        //Booksale Stuff
        Task<IList<BookSale>> GetAllBookSalesAsync();
        string GetBookSale();
        string GetBooksToPurchase();
       // void UpdateBookSale(string helloWorld);
        void DeleteBookSale(int id);
        void CreateBookSale(BookSaleNoID bookSaleNoId);
        
        //Customer stuff
        void UpdateCustomer(Customer customer);
        Customer GetCustomer();
    }
}
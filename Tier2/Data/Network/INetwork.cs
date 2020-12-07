using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.BookSale;
using Tier2.Models.Users;

namespace Tier2.Data
{
    public interface INetwork
    {
        //string GetAllBookSales();
        Task<IList<BookSale>> GetBookSaleAsync(string username);

        void UpdateBookSale(BookSale sale);
        void DeleteBookSale(int id);
        void CreateBookSale(BookSale bookSale);
        
        //Customer stuff
        void UpdateCustomer(Customer customer);
        void CreateCustomer(Customer customer);
        Task<IList<Customer>> GetCustomer(string username);
        void DeleteCustomer(string username);
        //void UpdateUser(User user);

        // User stuff
        void CreateUserAsync(User user);
        Task<IList<User>> GetUserListAsync(string username);
    }
}
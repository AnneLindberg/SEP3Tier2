

using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.Users;

namespace Tier2.Data
{
    public interface INetwork
    {
        //string GetAllBookSales();
        Task<IList<BookSale>> GetAllBookSalesAsync();

        string GetBookSale();
        string GetBooksToPurchase();
        void UpdateBookSale(string helloWorld);
        void UpdateCustomer(Customer customer);
        
        Task<Customer> GetCustomer();
        void UpdateUser(User user);

        Task<User> GetUser();
        void CreateCustomer(Customer customer);
    }
}
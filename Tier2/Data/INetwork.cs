

using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.Users;

namespace Tier2.Data
{
    public interface INetwork
    {
        string GetAllBookSales();
        string GetBookSale();
        string GetBooksToPurchase();
        void UpdateBookSale(string helloWorld);
        void UpdateCustomer(Customer customer);
        Customer GetCustomer();
    }
}
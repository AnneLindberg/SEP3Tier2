using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tier2.Data.Customer
{
    public interface ICustomerService
    {
        
        
            //Task<Customer> GetCustomerAsync();
       
            Task<Models.Customer> CreateCustomerAsync(Models.Customer customer);
            Task<IList<Models.Customer>> GetCustomerAsync(string username);
            Task<IList<Models.Customer>> GetAllCustomersAsync();
            Task DeleteCustomerAsync(string username);
            Task UpdateCustomerAsync(Models.Customer customer);
    }
}
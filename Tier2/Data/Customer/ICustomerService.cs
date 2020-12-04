using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models.Users;

namespace Tier2.Data
{
    public interface ICustomerService
    {
        
        
            //Task<Customer> GetCustomerAsync();
       
            Task<Customer> CreateCustomerAsync(Customer customer);
            Task<IList<Customer>> GetCustomerAsync(string username);
            Task<IList<Customer>> GetAllCustomersAsync();
            Task DeleteCustomerAsync(String username, string password);
            Task UpdateCustomerAsync(Customer customer);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models.Users;

namespace Tier2.Data
{
    public class CustomerService : ICustomerService
    {
        private readonly INetwork DBConn;
        private Customer customerToSend;

        public CustomerService()
        {
            DBConn = new NetworkSocket();
        }
        

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            DBConn.CreateCustomer(customer);
            return customer;
        }

        public async Task<IList<Customer>> GetCustomerAsync(string username) {
            return await DBConn.GetCustomer(username);
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteCustomerAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
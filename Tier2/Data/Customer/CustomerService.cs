using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Data.Network;

namespace Tier2.Data.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly INetwork DBConn;
        private Models.Customer customerToSend;

        public CustomerService()
        {
            DBConn = new NetworkSocket();
        }
        

        public async Task<Models.Customer> CreateCustomerAsync(Models.Customer customer)
        {
            DBConn.CreateCustomer(customer);
            return customer;
        }

        public async Task<IList<Models.Customer>> GetCustomerAsync(string username) {
            return await DBConn.GetCustomer(username);
        }

        public async Task<IList<Models.Customer>> GetAllCustomersAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteCustomerAsync(string username)
        {
            DBConn.DeleteCustomer(username);
        }

        public async Task UpdateCustomerAsync(Models.Customer customer)
        {
            DBConn.UpdateCustomer(customer);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Data.Network;
using Tier2.Models;
using Tier2.Models.Users;

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

        public async Task<double> GetRatingAsync(string username)
        {
            return await DBConn.GetRating(username);
        }

        public async Task<Rating> RateCustomerAsync(Rating rating)
        {
            DBConn.RateCustomer(rating);
            return rating;
            
        }
    }
}
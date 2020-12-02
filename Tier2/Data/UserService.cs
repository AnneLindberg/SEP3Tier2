using System;
using System.Collections;
 using System.Collections.Generic;
 using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tier2.Data;
using Tier2.Models.Users;
 using Tier2.Network;
 using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tier2.Data
{
    public class UserService : IUserService
    { 
        
        private readonly INetwork DBConn;
        private Customer customerToSend;
        private User userToSend;

        public UserService()
        {
            DBConn = new NetworkSocket();
        }
        
        public async Task AddCustomerAsyncTask(Customer customer)
        {
            DBConn.UpdateCustomer(customer);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            DBConn.CreateCustomer(customer);
            return customer;
        }
        
        public async Task<User> GetUserAsync(User user)
        {
            userToSend = await DBConn.GetSpecificUserAsync(user);
            return userToSend;
        }

        public async Task<Customer> GetCustomerAsync()
        {
            customerToSend = await DBConn.GetCustomer();
            Console.WriteLine(customerToSend);
            return customerToSend;
        }

        public Task CreateUserAsyncTask(User user)
        {
            throw new NotImplementedException();
        }
    }
}
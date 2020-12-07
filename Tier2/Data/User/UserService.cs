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
        

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            DBConn.CreateCustomer(customer);
            return customer;
        }
    


        public async Task<User> CreateUserAsync(User user)
        {
            DBConn.UpdateUser(user);
            return user;
        }

        public async Task<IList<User>> GetUserListAsync(string username)
        {
            return await DBConn.GetUserListAsync(username);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models.Users;


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
            DBConn.CreateUserAsync(user);
            return user;
        }

        public async Task<IList<User>> GetUserListAsync(string username)
        {
            return await DBConn.GetUserListAsync(username);
        }
    }
}
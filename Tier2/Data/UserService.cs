using System;
using System.Threading.Tasks;
using SEP3_Tier1.Data;
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
        
        public async Task AddCustomerAsyncTask(Customer customer)
        {
            DBConn.UpdateCustomer(customer);
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

        public async Task AddUserAsyncTask(User user)
        {
            DBConn.UpdateUser(user);
        }
    }
}
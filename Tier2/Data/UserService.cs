﻿using System;
 using System.Threading.Tasks;
 using Tier2.Data;
using Tier2.Models.Users;

 namespace SEP3_Tier1.Data
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

        public async Task<User> GetUserAsync()
        {
            userToSend = await DBConn.GetUser();
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
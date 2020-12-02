﻿using System.Threading.Tasks;
using Tier2.Models.Users;

 namespace SEP3_Tier1.Data
{
    public interface IUserService
    
    {
        Task AddCustomerAsyncTask(Customer customer);
        Task<Customer> GetCustomerAsync();
        Task CreateUserAsyncTask(User user);

        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<User> GetUserAsync();
    }
}
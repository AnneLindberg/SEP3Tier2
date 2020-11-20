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

namespace SEP3_Tier1.Data
{
    public class CustomerService : ICustomerService
    { 
        
        private readonly INetwork DBConn;
        private Customer customerToSend; 

        public CustomerService()
        {
            DBConn = new NetworkSocket();
        }
        
        public async Task AddCustomerAsyncTask(Customer customer)
        {
            DBConn.UpdateCustomer(customer);
        }

        public async Task<Customer> GetCustomerAsync()
        {
            customerToSend = DBConn.GetCustomer();
            Console.WriteLine(customerToSend);
            return customerToSend;
        }
    }
}
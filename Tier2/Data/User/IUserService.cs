using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models.Users;

 namespace Tier2.Data
{
    public interface IUserService
    
    {
        
        //Task<Customer> GetCustomerAsync();
       
        Task<Customer> CreateCustomerAsync(Customer customer);
        
        //User stuff
        Task<User> CreateUserAsync(User user);
        Task<User> GetSpecificUserAsync(string username);
        Task<IList<User>> GetAllUsersAsync();
    }
}
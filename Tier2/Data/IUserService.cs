using System.Threading.Tasks;
using Tier2.Models.Users;

 namespace Tier2.Data
{
    public interface IUserService
    
    {
        
        Task<Customer> GetCustomerAsync();
        Task CreateUserAsyncTask(User user);
        Task<Customer> CreateCustomerAsync(Customer customer);
        
        //User stuff
        Task<User> GetUserAsync(User user);
        Task<User> GetSpecificUserAsync(string username, string password);
    }
}
using System.Threading.Tasks;
using Tier2.Models.Users;

 namespace Tier2.Data
{
    public interface IUserService
    
    {
        Task AddCustomerAsyncTask(Customer customer);
        Task<Customer> GetCustomerAsync();
        Task CreateUserAsyncTask(User user);

        //User stuff
        Task<User> GetUserAsync(User user);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<User> GetUserAsync();
    }
}
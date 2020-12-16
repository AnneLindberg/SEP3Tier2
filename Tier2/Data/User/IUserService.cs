using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tier2.Data.User
{
    public interface IUserService
    {
        
        //Task<Customer> GetCustomerAsync();
       
        //Task<Models.Customer> CreateCustomerAsync(Models.Customer customer);
        
        //User stuff
        Task<Models.User> CreateUserAsync(Models.User user);
        Task<IList<Models.User>> GetUserListAsync(string username);
        Task<Models.User> GetSpecificUserLoginAsync(string username, string password);
        Task UpdateUserAsync(Models.User user);
        Task DeleteUserAsync(string username);
    }
}
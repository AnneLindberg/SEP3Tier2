using System.Threading.Tasks;
using Tier2.Models.Users;

 namespace SEP3_Tier1.Data
{
    public interface ICustomerService
    
    {
        Task AddCustomerAsyncTask(Customer customer);
        Task<Customer> GetCustomerAsync();
    }
}
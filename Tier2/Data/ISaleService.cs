using System.Threading.Tasks;

namespace Tier2.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<string> GetSaleAsync();
        Task AddSaleAsync(string sale);
        Task RemoveSaleAsync(string sale);
        Task<string> UpdateAsync(string sale);
    }
}
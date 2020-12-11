using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace TestTier2
{
    public interface IPurchaseService
    {
        public Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username);
        public Task<IList<PurchaseRequest>> GetPurchaseRequestFromIdAsync(int id);
        public Task<IList<PurchaseRequest>> CreatePurchaseRequestAsync(IList<PurchaseRequest> purchaseRequests);
        public Task DeletePurchaseRequestAsync(int id);
    }
}
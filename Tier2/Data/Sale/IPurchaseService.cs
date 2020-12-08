using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace Tier2.Data
{
    public interface IPurchaseService
    {
        public Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username);
        public Task<IList<PurchaseRequest>> CreatePurchaseRequest(IList<PurchaseRequest> purchaseRequests);
        public Task RemovePurchaseRequest(int id);
    }
}
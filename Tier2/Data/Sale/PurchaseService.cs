using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace Tier2.Data
{
    public class PurchaseService : IPurchaseService
    {
        private readonly INetwork DBConn;

        public PurchaseService() {
            DBConn = new NetworkSocket();
        }
        
        
        public Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username) {
            throw new System.NotImplementedException();
        }

        public async Task<IList<PurchaseRequest>> CreatePurchaseRequest(IList<PurchaseRequest> purchaseRequests) {
            DBConn.CreatePurchaseRequest(purchaseRequests);

            return purchaseRequests;
        }

        public Task RemovePurchaseRequest(int id) {
            throw new System.NotImplementedException();
        }
    }
}
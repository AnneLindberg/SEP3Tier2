using System;
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
        
        
        public async Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username) {
            return await DBConn.GetPurchaseRequest(username);
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
using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Data.Network;
using Tier2.Models;

namespace Tier2.Data.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly INetwork DBConn;

        public PurchaseService() {
            DBConn = new NetworkSocket();
        }
        
        
        public async Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username) {
            return await DBConn.GetPurchaseRequestAsync(username);
        }

        public async Task<IList<PurchaseRequest>> GetPurchaseRequestFromIdAsync(int id) {
            return await DBConn.GetPurchaseRequestFromIdAsync(id);
        }

        public async Task<IList<PurchaseRequest>> CreatePurchaseRequestAsync(IList<PurchaseRequest> purchaseRequests) {
            DBConn.CreatePurchaseRequest(purchaseRequests);

            return purchaseRequests;
        }

        public async Task DeletePurchaseRequestAsync(int id) {
            
            DBConn.DeletePurchaseRequest(id);
        }

        public async Task DeletePurchaseRequestFromSaleIdAsync(int id) {
            DBConn.DeletePurchaseRequestFromSaleId(id);
        }
    }
}
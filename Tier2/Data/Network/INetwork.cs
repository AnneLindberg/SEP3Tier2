using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace Tier2.Data.Network
{
    public interface INetwork
    {
        //string GetAllBookSales();
        Task<IList<BookSale>> GetBookSaleAsync(string username);

        void UpdateBookSale(BookSale sale);
        void DeleteBookSale(int id);
        void CreateBookSale(BookSale bookSale);
        
        //Customer stuff
        void UpdateCustomer(Models.Customer customer);
        void CreateCustomer(Models.Customer customer);
        Task<IList<Models.Customer>> GetCustomer(string username);
        void DeleteCustomer(string username);
        //void UpdateUser(User user);

        // User stuff
        void CreateUserAsync(Models.User user);
        Task<IList<Models.User>> GetUserListAsync(string username);
        
        //Purchase Request
        void CreatePurchaseRequest(IList<PurchaseRequest> purchaseRequests);
        Task<IList<PurchaseRequest>> GetPurchaseRequest(string username);
        Task<IList<PurchaseRequest>> GetPurchaseRequestFromId(int id);
        void DeletePurchaseRequest(int id);
    }
}
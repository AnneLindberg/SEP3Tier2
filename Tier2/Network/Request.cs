using System.Collections.Generic;
using Tier2.Models;

namespace Tier2.Network
{
    public class Request
    {
        public EnumRequest EnumRequest { get; set; }
        
        public BookSale BookSale { get; set; }
        
        // public BookSaleNoID BookSaleNoId { get; set; }
        public User User { get; set; }
        public Customer Customer { get; set; }
        public int Id { get; set; }
        public Rating rating { get; set; }
        
        //User
        public string username { get; set; }
        public string password { get; set; }
        
        //Purchase Request
        public IList<PurchaseRequest> purchaseRequests { get; set; }



        // Prototype
    }
    
}
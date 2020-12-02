using Tier2.Models;
using Tier2.Models.BookSale;
using Tier2.Models.Users;

namespace Tier2.Network
{
    public class Request
    {
        public EnumRequest EnumRequest { get; set; }
        
        public BookSale BookSale { get; set; }
        // public BookSaleNoID BookSaleNoId { get; set; }
        public User User { get; set; }
        public Customer Customer { get; set; }
        public Card Card { get; set; }
        public int Id { get; set; }
        
        //User
        public string username { get; set; }
        public string password { get; set; }


        // Prototype
        public string HelloWorld { get; set; }
    }
    
}
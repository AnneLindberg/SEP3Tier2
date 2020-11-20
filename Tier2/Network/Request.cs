﻿using Tier2.Models;
using Tier2.Models.Users;

namespace Tier2.Network
{
    public class Request
    {
        public EnumRequest EnumRequest { get; set; }
        
        public BookSale BookSale { get; set; }
        public User User { get; set; }
        public Card Card { get; set; }
        


        // Prototype
        public string HelloWorld { get; set; }
    }
    
}
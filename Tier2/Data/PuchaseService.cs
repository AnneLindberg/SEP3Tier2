﻿using System;
 using System.Collections.Generic;
using System.Threading.Tasks;
 using Tier2.Data;
 using Tier2.Models;

 namespace Tier2.Data
{
    public class PurchaseService : IPurchaseService
    {
        private readonly INetwork DBConn;
        private BookSale _bookSale;

        public PurchaseService()
        {
            DBConn = new NetworkSocket();
        }

        public async Task<IList<BookSale>> GetBooksToPurchase()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveBookFromSale()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateBooksInCart()
        {
            throw new System.NotImplementedException();
        }

        public Task PurchaseBooksInCart()
        {
            throw new System.NotImplementedException();
        }
    }
}
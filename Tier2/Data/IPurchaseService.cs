﻿using System.Collections.Generic;
using System.Threading.Tasks;
 using Tier2.Models;


 namespace SEP3_Tier1.Data
{
    public interface IPurchaseService
    {
        Task<IList<BookSale>> GetBooksToPurchase();
        Task RemoveBookFromSale();
        Task UpdateBooksInCart();
        Task PurchaseBooksInCart();
    }
}


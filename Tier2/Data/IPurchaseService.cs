﻿using System.Collections.Generic;
using System.Threading.Tasks;
 using Tier2.Models;
 using Tier2.Models.BookSale;


 namespace Tier2.Data
{
    public interface IPurchaseService
    {
        Task<IList<BookSale>> GetBooksToPurchase();
        Task RemoveBookFromSale();
        Task UpdateBooksInCart();
        Task PurchaseBooksInCart();
    }
}


﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public interface ISaleService
    {
        //Change to correct return types
        Task<string> GetSaleAsync();
        Task<string> AddSaleAsync(string sale);
        Task RemoveSaleAsync(string sale);
        Task<string> UpdateAsync(string sale);
    }
}
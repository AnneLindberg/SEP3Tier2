﻿using System;
 using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
 using Tier2.Data;
 using Tier2.Network;
 using WebAPI.Data;

 namespace SEP3_Tier1.Data
{
    public class SaleService : ISaleService
    {
        private string salesFile = "sales.json";
        private INetwork DBConn;
        private IList<string> sales;


        public SaleService() {
            DBConn = new NetworkSocket();
            
        }
        
        
        
        public async Task<IList<string>> GetSaleAsync() { 
            sales = DBConn.GetBookSale();
            return sales;
        }

        public async Task<string> AddSaleAsync(string sale) {
            sales.Add(sale);
            DBConn.UpdateBookSale(sale);
            return sale;

        }

        public async Task RemoveSaleAsync(string sale) {
            string toRemove = sales.First(t => t.Equals(sale));
            sales.Remove(toRemove);
            WriteSalesToFile();
        }


       
        public async Task<string> UpdateAsync(string sale) {
            string toUpdate = sales.FirstOrDefault(t => t.Equals(sale));
            if (toUpdate == null) throw new Exception($"Did not find sale matching");
            WriteSalesToFile();
            return toUpdate;
        }
        
        
        private void WriteSalesToFile() {
            string productAsJson = JsonSerializer.Serialize(sales);
            
            File.WriteAllText(salesFile, productAsJson);
        }

        private void Seed() {
            string[] salesList = {
                "Hello World",
                "Hello Sonny Boi",
                "Hello Markus"
            };
            sales = salesList.ToList();
        }
    }
}
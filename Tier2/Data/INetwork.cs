

using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Models;

namespace Tier2.Data
{
    public interface INetwork
    {
        string GetBookSale();
        string GetBooksToPurchase();
        void UpdateBookSale(string helloWorld);

    }
}
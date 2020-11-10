using System.Collections.Generic;
using System.Threading.Tasks;
using Tier2.Network;

namespace Tier2.Data
{
    public interface INetwork
    {
        IList<string> GetBookSale();
        void UpdateBookSale(string helloWorld);

    }
}
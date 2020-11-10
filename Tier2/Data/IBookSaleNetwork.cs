using SEP3_Tier1.Models;

namespace Tier2.Network
{
    public interface IBookSaleNetwork
    {
        public @string GetBookSale(string helloWorld);
        public void UpdateBookSale(string helloWorld);
    }
}

//TODO:: maybe change the Models and add a dummy model with a hello string? instead of passing the BookSale object. Depends on what is on the other tiers
//TODO:: check Tier1 localhost. Does it have to be the same? 
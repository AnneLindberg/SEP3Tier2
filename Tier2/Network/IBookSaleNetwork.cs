using SEP3_Tier1.Models;

namespace Tier2.Network
{
    public interface IBookSaleNetwork
    {
        public BookSale GetBookSale(string helloWorld);
        public void UpdateBookSale(BookSale bookSale);

    }
}

//TODO:: is it a console app? Why does it have pages then?   
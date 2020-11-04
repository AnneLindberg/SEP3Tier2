using SEP3_Tier1.Models;

namespace Tier2.Network
{
    public interface IBookSaleNetwork
    {
        public BookSale GetBookSale(string title);
        public void UpdateBookSale(BookSale bookSale);

    }
}
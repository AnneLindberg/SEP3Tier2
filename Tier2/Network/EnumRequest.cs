using System.Text.Json.Serialization;

namespace Tier2.Network
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumRequest
    {
        //BookSale
        CreateBookSale,
        GetBookSpecificBookSale,
        GetAllBookSales,
        UpdateBookSale,
        DeleteBookSale,
        
        //Users
        CreateUser,
        GetSpecificUserLogin,
        GetUserList,
        UpdateUser,
        DeleteUser,
        RateUser,
        
        //Customers
        CreateCustomer,
        GetSpecificCustomer,
        UpdateCustomer,
        DeleteCustomer,
        GetRatings,
        Rate,

        // Prototype
        recieveProofOfConcept,
        sendProofOfConcept,
        
    }
}
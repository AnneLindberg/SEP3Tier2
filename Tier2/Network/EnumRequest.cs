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
        GetSpecificUser,
        GetAllUsers,
        UpdateUser,
        DeleteUser,
        RateUser,
        
        //Customers
        CreateCustomer,
        GetCustomer,
        UpdateCustomer,
        DeleteCustomer,
        
        // Prototype
        recieveProofOfConcept,
        sendProofOfConcept
    }
}
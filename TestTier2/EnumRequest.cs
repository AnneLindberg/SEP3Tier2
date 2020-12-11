using System.Text.Json.Serialization;

namespace TestTier2
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
        GetUserList,
        UpdateUser,
        DeleteUser,
        RateUser,
        
        //Customers
        CreateCustomer,
        GetCustomer,
        UpdateCustomer,
        DeleteCustomer,
        GetRatings,
        Rate,
        
        // Prototype
        recieveProofOfConcept,
        sendProofOfConcept,
        GetPurchaseRequest
    }
}
using System.Text.Json.Serialization;

namespace TestTier2
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumRequest
    {
        // Creating new objects in database
        CreateBookSaleNoID,
        CreateUser,
        
        // Getting from database
        GetBookSale,
        GetAllBookSales,
        GetUser,
        GetCard,
        
        // Selling Book
        SellBook,
        
        // Deleting objects from database
        DeleteSale,
        DeleteUser,
        DeleteCard,
        
        // Rate user
        RateUser,

        // Prototype
        recieveProofOfConcept,
        sendProofOfConcept
    }
}
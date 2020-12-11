using System.Text.Json.Serialization;

namespace Tier2.Network
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumRequest
    {
        //BookSale
        CreateBookSale,
        GetAllBookSales,
        UpdateBookSale,
        DeleteBookSale,
        
        //Users
        CreateUser,
        GetSpecificUserLogin,
        GetUserList,
        UpdateUser,
        DeleteUser,
        GetRatings,
        Rate,
        
        //Customers
        CreateCustomer,
        GetSpecificCustomer,
        UpdateCustomer,
        DeleteCustomer,
        
        //PurchaseRequest
        CreatePurchaseRequest,
        GetPurchaseRequest,
        GetPurchaseRequestFromId,
        DeletePurchaseRequest,
        DeletePurchaseRequestFromSaleId

        
    }
}
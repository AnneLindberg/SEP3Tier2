using System.Text.Json.Serialization;

namespace Tier2.Models
{
    public class PurchaseRequest
    {
        [JsonPropertyName("requestID")] 
        public int? requestID { get; set; } = null;
 
        [JsonPropertyName("bookSale")]
        public BookSale bookSale { get; set; }
        
        [JsonPropertyName("buyer")]
        public string buyer { get; set; }
        
        [JsonPropertyName("seller")]
        public string seller { get; set; }
    }
}
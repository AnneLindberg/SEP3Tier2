using System.Text.Json.Serialization;

namespace Tier2.Models
{
    public class Card
    {
        [JsonPropertyName("cardNumber")]
        public int CardNumber { get; set; }
        
        [JsonPropertyName("cvv")]
        public int Cvv { get; set; }
        
        [JsonPropertyName("expirationMonth")]
        public int ExpirationMonth { get; set; }
        
        [JsonPropertyName("expirationYear")]
        public int ExpirationYear { get; set; }
        
        [JsonPropertyName("id")]
        public string Type { get; set; }


        public override string ToString()
        {
            return CardNumber + "/" + Cvv + "/" + ExpirationMonth + "/" + ExpirationYear + "/" + Type;
        }
    }
}
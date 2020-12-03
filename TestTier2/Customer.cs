using System.Text.Json.Serialization;

namespace TestTier2
{
    public class Customer
    {
        
        [JsonPropertyName("postcode")]
        public string postcode { get; set; }
        
        [JsonPropertyName("address")]
        public string address { get; set; }
        
        [JsonPropertyName("firstName")]
        public string firstName { get; set; }
        
        [JsonPropertyName("lastName")]
        public string lastName { get; set; }
        
        [JsonPropertyName("email")]
        public string email { get; set; }
        
        [JsonPropertyName("phoneNumber")]
        public int phoneNumber { get; set; }
        
        [JsonPropertyName("rating")]
        public double rating { get; set; }
    }
}
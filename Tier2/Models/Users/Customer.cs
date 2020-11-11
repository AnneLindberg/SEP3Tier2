using System.Text.Json.Serialization;

namespace Tier2.Models.Users
{
    public class Customer : User
    {
        [JsonPropertyName("location")]
        public string location { get; set; }
        
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
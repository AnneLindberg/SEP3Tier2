using System.Text.Json.Serialization;

namespace TestTier2
{
    public class Rating
    {
        [JsonPropertyName("username")]
        public string username { get; set;}
        
        [JsonPropertyName("rating")]
        public double rating { get; set;}
        
        [JsonPropertyName("otherUsername")]
        public string otherUsername { get; set;}
    }
}
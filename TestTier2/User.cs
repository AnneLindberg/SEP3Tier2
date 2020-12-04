using System.Text.Json.Serialization;

namespace TestTier2
{
    public class User
    {
        
        [JsonPropertyName("username")]
        public string username { get; set; }
        
        [JsonPropertyName("password")]
        public string password { get; set; }
        
        [JsonPropertyName("role")]
        public string  role { get; set; }
    }
}
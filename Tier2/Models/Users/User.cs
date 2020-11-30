using System.Text.Json.Serialization;

namespace Tier2.Models.Users
{
    public class User
    {
        [JsonPropertyName("username")]
        public string username { get; set; }
        
        [JsonPropertyName("password")]
        public string password { get; set; }
        
        [JsonPropertyName("role")]
        public int role { get; set; }
    }
}
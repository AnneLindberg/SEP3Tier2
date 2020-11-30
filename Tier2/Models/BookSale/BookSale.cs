using System.Text.Json.Serialization;

namespace Tier2.Models.BookSale
{
    public class BookSale
    {
        [JsonPropertyName("title")]
        public string title { get; set; }
        
        [JsonPropertyName("author")]
        public string author { get; set; }
        
        [JsonPropertyName("edition")]
        public string edition { get; set; }
        
        [JsonPropertyName("condition")]
        public string condition { get; set; }
        
        [JsonPropertyName("subject")]
        public string subject { get; set; }
        
        [JsonPropertyName("image")]
        public string image { get; set; }
        
        [JsonPropertyName("price")]
        public double price { get; set; }
        
        [JsonPropertyName("hardCopy")]
        public bool hardCopy { get; set; }
        
        [JsonPropertyName("description")]
        public string description { get; set; }
        
        [JsonPropertyName("username")]
        public string username { get; set; }

        //Create method to autogenerate ID value
        [JsonPropertyName("bookSaleID")]
        public int? bookSaleID { get; set; }

        public override string ToString()
        {
            return "{"
                   + "\"title\":" + "\"" + title + "\","
                   + "\"author\":" + "\"" + author + "\","
                   + "\"edition\":" + "\"" + edition + "\","
                   + "\"condition\":" + "\"" + condition + "\","
                   + "\"subject\":" + "\"" + subject + "\","
                   + "\"image\":" + "\"" + image + "\","
                   + "\"price\":" + price + ","
                   + "\"hardCopy\":"  + hardCopy + ","
                   + "\"description\":" + "\"" + description + "\"" +","
                   + "\"username\":" + "\"" + username + "\"" +","
                   + "\"id\":" + bookSaleID
                   + "}";
        }
    }
    
    
}
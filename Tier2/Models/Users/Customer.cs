namespace SEP3_Tier1.Models
{
    public class Customer : User
    {
        public string location { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public double rating { get; set; }
    }
}
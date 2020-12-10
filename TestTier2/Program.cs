using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace TestTier2
{
    class Program
    {
        //public static TcpClient tcpClient = new TcpClient("localhost",1236);
        //public static Stream stream = tcpClient.GetStream();

        public static Rating rating1 = new Rating {username = "Crisiluluman", rating = 4.4, otherUsername = "SonSon"};
        public static string username = "Crisiluluman";
        
        public static User user = new User{username = "Mod1", password = "921837897", role = "Moderator"};
        private string password = "1231231";

        static void Main(string[] args)
        {
            Console.WriteLine("work?");
            TcpClient tcpClient = new TcpClient("localhost", 1236);
            Stream stream = tcpClient.GetStream();

          



/*
            string getRating = JsonSerializer.Serialize(new Request
            {
                username = username,
                EnumRequest = EnumRequest.GetRatings
            });

            byte[] recieveRating = Encoding.ASCII.GetBytes(getRating);
            stream.Write(recieveRating, 0, recieveRating.Length);
            byte[] fromServer = new byte[1024 * 1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            IList<double> rating = JsonSerializer.Deserialize<IList<double>>(recieved);

            double averageRating = rating.Average();
            Console.WriteLine($"The avg rating {averageRating}");
            */
        }
    }

    /*public static void CreateConnection()
     {
         tcpClient = new TcpClient("localhost", 1236);
         stream = tcpClient.GetStream();
     }

     public static void CloseConnection()
     {
         tcpClient.Close();
         stream.Close();
     }*/
}
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace TestTier2
{
    class Program
    {
        //public static TcpClient tcpClient = new TcpClient("localhost",1236);
        //public static Stream stream = tcpClient.GetStream();
        
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost",1236);
            Stream stream = tcpClient.GetStream();
            
            string request = JsonSerializer.Serialize(new Request
            {
                BookSaleNoId = new BookSaleNoID()
                {
                    title = "Max",
                    author = "chr",
                    edition = "Test",
                    condition = "1st",
                    subject = "true maths",
                    image = "png",
                    price = 200.00,
                    hardCopy = true,
                    username = "Idunno",
                    description = "i",
                },
                EnumRequest = EnumRequest.CreateBookSaleNoID
            });

            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);
            Console.WriteLine(request);

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
}
using System;
using System.Collections.Generic;
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

        public static string username1 = "Crisiluluman";
        public static string username2 = null;
        
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost",1236);
            Stream stream = tcpClient.GetStream();


            string deleteRequest = JsonSerializer.Serialize(new Request
            {
                username = username1,
                EnumRequest = EnumRequest.DeleteCustomer
            });

            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(deleteRequest);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);

            Console.WriteLine("Removed");
            
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
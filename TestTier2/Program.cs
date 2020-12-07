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
        
        public static User user = new User {username = "Test1", password = "1234", role = "Admin"};
        
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost",1236);
            Stream stream = tcpClient.GetStream();
            
            string deleteRequest = JsonSerializer.Serialize(new Request
            {
                User = user,
                EnumRequest = EnumRequest.CreateUser
            });

            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(deleteRequest);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);

            
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
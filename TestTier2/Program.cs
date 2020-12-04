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
   
            
            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.GetUserList,
                username = username2
            });
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
            //Console.WriteLine("Test here?");
            byte[] fromServer = new byte[1024 * 1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            //Console.WriteLine("Rigtht here?");
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            Console.WriteLine("\n" + recieved);
            IList<User> userFromDb = JsonSerializer.Deserialize<IList<User>>(recieved);

            for (int i = 0; i < userFromDb.Count; i++)
            {
                Console.WriteLine(userFromDb[i].username);
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
}
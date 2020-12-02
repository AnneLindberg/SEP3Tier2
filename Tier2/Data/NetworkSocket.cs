using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.Users;
using Tier2.Network;

namespace Tier2.Data
{
    public class NetworkSocket : INetwork
    {
        private TcpClient _tcpClient;
        private NetworkStream stream;

        public void CreateConnection()
        {
            _tcpClient = new TcpClient("localhost", 1236);
            stream = _tcpClient.GetStream();
        }
        
        /* public string GetAllBookSales()
         {
             string recieveStuff = JsonSerializer.Serialize(new Request
             {
                 RequestEnum = EnumRequest.GetAllBookSales
             });
             byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
             stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
             Console.WriteLine("TEST1");
             byte[] fromServer = new byte[1024];
             int read = stream.Read(fromServer, 0, fromServer.Length);
             string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
             Console.WriteLine(recieved + " recieved");
             string jsonString = JsonSerializer.Deserialize<string>(recieved);
             Console.WriteLine(jsonString + "<-- The string");
             return jsonString;
             
         }*/

        public async Task<IList<BookSale>> GetAllBookSalesAsync()
        {
            CreateConnection(); //Incase shit goes south create close the connection at the end of the method as well
            
            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.GetAllBookSales
            });
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
            //Console.WriteLine("Test here?");
            byte[] fromServer = new byte[1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            //Console.WriteLine("Rigtht here?");
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            Console.WriteLine("\n" + recieved);
            IList<BookSale> jsonString = JsonSerializer.Deserialize<IList<BookSale>>(recieved);

            return jsonString;
        }


        public string GetBookSale()
        {
            
            //læs fra serveren
            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.recieveProofOfConcept
            });
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);

            byte[] fromServer = new byte[1024];
            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            string jsonString = JsonSerializer.Deserialize<string>(recieved);

            Console.WriteLine(jsonString);
            return jsonString;
        }

        public string GetBooksToPurchase()
        {
            throw new NotImplementedException();
        }


        public void UpdateBookSale(string helloWorld)
        {
            Console.WriteLine(helloWorld);
            string request = JsonSerializer.Serialize(new Request
            {
                HelloWorld = helloWorld,
                EnumRequest = EnumRequest.sendProofOfConcept
            });

            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);
        }
        
        public void UpdateCustomer(Customer customer)
        {
            Console.WriteLine(customer);
            string request = JsonSerializer.Serialize(new Request
            {
                Customer = customer,
                EnumRequest= EnumRequest.CreateUser
            });
            
            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);        
        }
        
        public async Task<Customer> GetCustomer()
        {
            CreateConnection();
            string recieveCustomer = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.GetCustomer
            });
            byte[] recieveCustomerSend = Encoding.ASCII.GetBytes(recieveCustomer);
            stream.Write(recieveCustomerSend,0,recieveCustomerSend.Length);
            byte[] fromServer = new byte[1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string json = Encoding.ASCII.GetString(fromServer, 0, read);
            Customer jsonCustomer = JsonSerializer.Deserialize<Customer>(json);

            return jsonCustomer;
        }
        
        public void UpdateUser(User user)
        {
            Console.WriteLine(user);
            string request = JsonSerializer.Serialize(new Request
            {
                User = user,
                EnumRequest = EnumRequest.CreateCustomer
            });

            byte[] sendUpdatedCustomer = Encoding.ASCII.GetBytes(request);
            stream.Write(sendUpdatedCustomer,0,sendUpdatedCustomer.Length);
        }

        /*public async Task<User> GetUser()
        {
         
            CreateConnection();
            string recieveUser = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.GetUser
            });
            byte[] recieveUserToSend = Encoding.ASCII.GetBytes(recieveUser);
            stream.Write(recieveUserToSend,0,recieveUserToSend.Length);
            byte[] fromServer = new byte[1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string json = Encoding.ASCII.GetString(fromServer, 0, read);
            User jsonUser = JsonSerializer.Deserialize<User>(json);

            return jsonUser;
        }
        */

        public async Task<User> GetSpecificUserAsync(string username, string password)
        {
            CreateConnection();

            string recieveUser = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.GetSpecificUser,
                username = username,
                password = password
            });
            byte[] recieveUserToSend = Encoding.ASCII.GetBytes(recieveUser);
            stream.Write(recieveUserToSend,0,recieveUserToSend.Length);
            byte[] fromServer = new byte[1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string json = Encoding.ASCII.GetString(fromServer, 0, read);
            Console.WriteLine(json);
            User jsonUser = JsonSerializer.Deserialize<User>(json);
            return jsonUser;
        }

        private Request WriteFromServer(string s)
        {
            var dataToServer = Encoding.ASCII.GetBytes(s);
            stream.Write(dataToServer, 0, dataToServer.Length);
            var fromServer = new byte[1024];
            var bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            var response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            var requestT3 = JsonSerializer.Deserialize<Request>(response);
            return requestT3;
        }
    }
}
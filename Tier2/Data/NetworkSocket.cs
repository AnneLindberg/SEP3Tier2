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
        //Initial branch
        private TcpClient _tcpClient;
        private NetworkStream stream;

       
        
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
            IList<BookSale> bookSalesFromDb = JsonSerializer.Deserialize<IList<BookSale>>(recieved);
            
            CloseConnection();
            
            return bookSalesFromDb;
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


        /*
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
        */
        
        public void DeleteBookSale(int id) {
            CreateConnection();
            
            string deleteRequest = JsonSerializer.Serialize(new Request {
                EnumRequest = EnumRequest.DeleteSale
            });
            
            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(deleteRequest);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);
            
            CloseConnection();
            
            // Todo create method that sends a confirmation back that the sale has been deleted
        }

        public void CreateBookSale(BookSaleNoID bookSaleNoId)
        {
            CreateConnection();
            Console.WriteLine("IM IN THE HOLE CREATEBOOKSALE START");

            string request = JsonSerializer.Serialize(new Request
            {
                BookSaleNoId = bookSaleNoId,
                EnumRequest = EnumRequest.CreateBookSaleNoID
            });

            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);
            Console.WriteLine("IM IN THE HOLE CREATEBOOKSALE SLUT");

            CloseConnection();
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

        public Customer GetCustomer()
        {
            throw new NotImplementedException();
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
        
        
        
        private void CreateConnection()
        {
            _tcpClient = new TcpClient("localhost", 1236);
            stream = _tcpClient.GetStream();
        }

        private void CloseConnection()
        {
            _tcpClient.Close();
            stream.Close();
        }
    }
}
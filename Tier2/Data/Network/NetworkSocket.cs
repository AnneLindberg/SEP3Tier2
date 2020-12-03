using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Models.BookSale;
using Tier2.Models.Users;
using Tier2.Network;

namespace Tier2.Data
{
    public class NetworkSocket : INetwork
    {
        //Initial branch
        private TcpClient _tcpClient;
        private NetworkStream stream;

        public void CreateConnection()
        {
            _tcpClient = new TcpClient("localhost", 1236);
            stream = _tcpClient.GetStream();
        }

        private void CloseConnection()
        {
            _tcpClient.Close();
            stream.Close();
        }
        

        #region BookSales

        
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
            byte[] fromServer = new byte[1024 * 1024];

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
        
        
        public void DeleteBookSale(int id) {
            CreateConnection();
            
            string deleteRequest = JsonSerializer.Serialize(new Request {
                Id = id,
                EnumRequest = EnumRequest.DeleteBookSale
            });
            
            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(deleteRequest);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);
            
            CloseConnection();
            Console.WriteLine("Removed");
            
            // Todo create method that sends a confirmation back that the sale has been deleted
        }

        public void CreateBookSale(BookSale bookSale)
        {
            CreateConnection();
            Console.WriteLine("IM IN THE HOLE CREATEBOOKSALE START");

            string request = JsonSerializer.Serialize(new Request
            {
                BookSale = bookSale,
                EnumRequest = EnumRequest.CreateBookSale
            });

            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);
            Console.WriteLine("IM IN THE HOLE CREATEBOOKSALE SLUT");
            Console.WriteLine(bookSale);

            CloseConnection();
        }
        
        #endregion

        

        #region Users

        public void CreateCustomer(Customer customer)
        {
            CreateConnection();
            Console.WriteLine("IM IN THE HOLE CreateCustomer START");

            string request = JsonSerializer.Serialize(new Request
            {
                Customer = customer,
                EnumRequest = EnumRequest.CreateCustomer
            });

            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);
            Console.WriteLine("IM IN THE HOLE CreateCustomer SLUT");
            Console.WriteLine(customer);
        }

        public async Task<IList<Customer>> GetCustomer(string username)
        {
            CreateConnection();
            string recieveCustomer = JsonSerializer.Serialize(new Request
            {
                username = username,
                EnumRequest = EnumRequest.GetSpecificCustomer
            });
            
            byte[] recieveCustomerSend = Encoding.ASCII.GetBytes(recieveCustomer);
            stream.Write(recieveCustomerSend,0,recieveCustomerSend.Length);
            byte[] fromServer = new byte[1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string json = Encoding.ASCII.GetString(fromServer, 0, read);
            IList<Customer> jsonCustomer = JsonSerializer.Deserialize<IList<Customer>>(json);

            Console.WriteLine(jsonCustomer.ToString());
            return jsonCustomer;
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

        public Task<User> GetSpecificUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }


        public async Task<User> GetSpecificUserAsync(User user)
        {
            CreateConnection();
            string recieveUser = JsonSerializer.Serialize(new Request
            {
                User = user,
                EnumRequest = EnumRequest.GetSpecificUser
            });
            byte[] recieveUserToSend = Encoding.ASCII.GetBytes(recieveUser);
            stream.Write(recieveUserToSend,0,recieveUserToSend.Length);
            
            byte[] fromServer = new byte[1024];
            int read = stream.Read(fromServer, 0, fromServer.Length);
            string json = Encoding.ASCII.GetString(fromServer, 0, read);
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

    #endregion

}



/*
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
*/

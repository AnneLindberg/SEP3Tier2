using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tier2.Models;
using Tier2.Network;

namespace Tier2.Data.Network
{
    public class NetworkSocket : INetwork
    {
        //Initial branch
        private TcpClient _tcpClient;
        private NetworkStream stream;

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


        #region BookSales

        public async Task<IList<BookSale>> GetBookSaleAsync(string username)
        {
            CreateConnection(); //Incase shit goes south create close the connection at the end of the method as well

            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                username = username,
                EnumRequest = EnumRequest.GetAllBookSales
            });
            
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
            byte[] fromServer = new byte[1024 * 1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            IList<BookSale> bookSalesFromDb = JsonSerializer.Deserialize<IList<BookSale>>(recieved);

            CloseConnection();

            return bookSalesFromDb;
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
            
            // Todo create method that sends a confirmation back that the sale has been deleted
        }



        public void UpdateBookSale(BookSale sale)
        {
            CreateConnection();

            string updateRequest = JsonSerializer.Serialize(new Request
            {
                BookSale = sale,
                EnumRequest = EnumRequest.UpdateBookSale
            });

            byte[] updateRequestSend = Encoding.ASCII.GetBytes(updateRequest);
            stream.Write(updateRequestSend, 0, updateRequestSend.Length);
            CloseConnection();

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

            CloseConnection();
        }

        #endregion
        
        #region Users

        public void CreateUser(Models.User user)
        {
            CreateConnection();
            string createRequest = JsonSerializer.Serialize(new Request
            {
                User = user,
                EnumRequest = EnumRequest.CreateUser
            });
            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(createRequest);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);
            CloseConnection();
        }

        public async Task<Models.User> GetSpecificUserLoginAsync(string username, string password)
        {
            CreateConnection();

            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.GetSpecificUserLogin,
                username = username,
                password = password
            });
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
           
            byte[] fromServer = new byte[1024 * 1024];
            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            Models.User userFromDb = JsonSerializer.Deserialize<Models.User>(recieved);
            
            CloseConnection();
            
            return userFromDb;
        }

        public async Task<IList<Models.User>> GetUserListAsync(string username)
        {
            CreateConnection();

            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.GetUserList,
                username = username
            });
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
            byte[] fromServer = new byte[1024 * 1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);
            IList<Models.User> userFromDb = JsonSerializer.Deserialize<IList<Models.User>>(recieved);
            
            CloseConnection();
            
            return userFromDb;
        }

        public void UpdateUser(Models.User user)
        {
            CreateConnection();
            
            string updateUser = JsonSerializer.Serialize(new Request
            {
                User =  user,
                EnumRequest = EnumRequest.UpdateUser
            });

            byte[] userByte = Encoding.ASCII.GetBytes(updateUser);
            stream.Write(userByte, 0, userByte.Length);
            
            CloseConnection();
        }
        
        public void DeleteUser(string username)
        {
            CreateConnection();
            
            string recieveStuff = JsonSerializer.Serialize(new Request
            {
                EnumRequest = EnumRequest.DeleteUser,
                username = username
            });
            
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(recieveStuff);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
        }

        #endregion

        #region PurchaseRequest
        
        public void CreatePurchaseRequest(IList<PurchaseRequest> purchaseRequests) {
            CreateConnection();

            string request = JsonSerializer.Serialize(new Request {
                purchaseRequests = purchaseRequests,
                EnumRequest = EnumRequest.CreatePurchaseRequest
            });

            byte[] sendPurchaseRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendPurchaseRequest, 0, sendPurchaseRequest.Length);
            
            CloseConnection();
        }

        public async Task<IList<PurchaseRequest>> GetPurchaseRequestAsync(string username) {
            CreateConnection();
            
            string purchaseReceive = JsonSerializer.Serialize(new Request {
                username = username,
                EnumRequest = EnumRequest.GetPurchaseRequest
            });
            
            
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(purchaseReceive);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
            byte[] fromServer = new byte[1024 * 1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);


            IList<PurchaseRequest> requestsFromDb = JsonSerializer.Deserialize<IList<PurchaseRequest>>(recieved);
            
            CloseConnection();

            return requestsFromDb;
        }

        public async Task<IList<PurchaseRequest>> GetPurchaseRequestFromIdAsync(int id) {
            CreateConnection();
            
            Console.WriteLine(id);
            
            string purchaseReceive = JsonSerializer.Serialize(new Request {
                Id = id,
                EnumRequest = EnumRequest.GetPurchaseRequestFromId
            });
            
            
            byte[] recieveRequestSend = Encoding.ASCII.GetBytes(purchaseReceive);
            stream.Write(recieveRequestSend, 0, recieveRequestSend.Length);
            byte[] fromServer = new byte[1024 * 1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string recieved = Encoding.ASCII.GetString(fromServer, 0, read);


            IList<PurchaseRequest> requestsFromDb = JsonSerializer.Deserialize<IList<PurchaseRequest>>(recieved);
            
            CloseConnection();

            return requestsFromDb;
        }

        public void DeletePurchaseRequest(int id) {
            CreateConnection();
            string deletePurchase = JsonSerializer.Serialize(new Request
            {
                Id = id,
                EnumRequest = EnumRequest.DeletePurchaseRequest
            });

            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(deletePurchase);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);
            CloseConnection();
        }

        public void DeletePurchaseRequestFromSaleId(int id) {
            CreateConnection();

            string deletePurchaseFromSaleId = JsonSerializer.Serialize(new Request {
                Id = id,
                EnumRequest = EnumRequest.DeletePurchaseRequestFromSaleId
            });
            
            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(deletePurchaseFromSaleId);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);
            CloseConnection();
        }

        #endregion

        #region Customer

        public void CreateCustomer(Models.Customer customer)
        {
            CreateConnection();

            string request = JsonSerializer.Serialize(new Request
            {
                Customer = customer,
                EnumRequest = EnumRequest.CreateCustomer
            });

            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);
        }

        public async Task<IList<Models.Customer>> GetCustomerAsync(string username)
        {
            CreateConnection();
            string recieveCustomer = JsonSerializer.Serialize(new Request
            {
                username = username,
                EnumRequest = EnumRequest.GetSpecificCustomer
            });

            byte[] recieveCustomerSend = Encoding.ASCII.GetBytes(recieveCustomer);
            stream.Write(recieveCustomerSend, 0, recieveCustomerSend.Length);
            byte[] fromServer = new byte[1024];

            int read = stream.Read(fromServer, 0, fromServer.Length);
            string json = Encoding.ASCII.GetString(fromServer, 0, read);
            IList<Models.Customer> jsonCustomer = JsonSerializer.Deserialize<IList<Models.Customer>>(json);

            return jsonCustomer;
        }

        public void DeleteCustomer(string username)
        {
            CreateConnection();
            string deleteRequest = JsonSerializer.Serialize(new Request
            {
                username = username,
                EnumRequest = EnumRequest.DeleteCustomer
            });

            byte[] deleteRequestSend = Encoding.ASCII.GetBytes(deleteRequest);
            stream.Write(deleteRequestSend, 0, deleteRequestSend.Length);
            CloseConnection();
        }

        public void UpdateCustomer(Models.Customer customer)
        {
            CreateConnection();
            
            string request = JsonSerializer.Serialize(new Request
            {
                Customer = customer,
                EnumRequest = EnumRequest.UpdateCustomer
            });

            byte[] sendStuffRequest = Encoding.ASCII.GetBytes(request);
            stream.Write(sendStuffRequest, 0, sendStuffRequest.Length);
            CloseConnection();
        }

        public async Task<double> GetRatingAsync(string username)
        {
            CreateConnection();
            
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

            CloseConnection();
            double averageRating = rating.Average();
            return Math.Round(averageRating,1);
        }

        public void RateCustomer(Rating rating)
        {
            CreateConnection();
            
            string rate = JsonSerializer.Serialize(new Request
            {
                rating = rating,
                EnumRequest = EnumRequest.Rate
            });

            byte[] rateByte = Encoding.ASCII.GetBytes(rate);
            stream.Write(rateByte, 0, rateByte.Length);     
            Console.WriteLine($"Rating network: {rating.username} : {rating.rating} : {rating.otherUsername}");

            CloseConnection();
        }
        
        #endregion
    }
}


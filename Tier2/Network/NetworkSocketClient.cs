using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using SEP3_Tier1.Models;

namespace Tier2.Network
{
    public class Tier2Socket : IBookSaleNetwork
    {
        private TcpClient _tcpClient;
        private NetworkStream stream;

        public Tier2Socket()
        {
            _tcpClient = new TcpClient("127.0.0.1", 5000);
            stream = _tcpClient.GetStream();
        }


        public BookSale GetBookSale(string title)
        {
            string s = JsonSerializer.Serialize(new RequestT3
            {
                ob = title,
                title = " "
            });
            RequestT3 requestT3 = WriteFromServer(s);
            Console.Write(s);
            BookSale bookSale = JsonSerializer.Deserialize<BookSale>(requestT3.ob.ToString());
            return bookSale;
        }

       
        public void UpdateBookSale(BookSale bookSale)
        {
            throw new System.NotImplementedException();
        }
        
        private RequestT3 WriteFromServer(string s)
        {
            //this methods reads and writes to the server 
            byte[] dataToServer = Encoding.ASCII.GetBytes(s);
            stream.Write(dataToServer, 0, dataToServer.Length);
            byte[] fromServer = new byte[1024];
            int bytesRead = stream.Read(fromServer, 0, fromServer.Length);

            //Tar Imod Profile gennem sockets
            string response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            RequestT3 requestT3 = JsonSerializer.Deserialize<RequestT3>(response);
            return requestT3;
        }
    }
}
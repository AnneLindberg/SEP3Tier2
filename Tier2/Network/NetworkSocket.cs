using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using SEP3_Tier1.Models;

namespace Tier2.Network
{
    public class NetworkSocket : IBookSaleNetwork
    {
        private readonly TcpClient _tcpClient;
        private readonly NetworkStream stream;

        public NetworkSocket()
        {
            _tcpClient = new TcpClient("127.0.0.1", 1236);
            stream = _tcpClient.GetStream();
        }


        public BookSale GetBookSale(string helloWorld)
        {
            var s = JsonSerializer.Serialize(new RequestT3
            {
                ob = helloWorld,
                EnumRequest = EnumRequest.GETMESSAGEFROMDATABASE
            });
            var requestT3 = WriteFromServer(s);
            Console.Write(s);
            var bookSale = JsonSerializer.Deserialize<BookSale>(requestT3.ob.ToString());
            return bookSale;
        }


        public void UpdateBookSale(BookSale bookSale)
        {
            throw new NotImplementedException();
        }

        private RequestT3 WriteFromServer(string s)
        {
            var dataToServer = Encoding.ASCII.GetBytes(s);
            stream.Write(dataToServer, 0, dataToServer.Length);
            var fromServer = new byte[1024];
            var bytesRead = stream.Read(fromServer, 0, fromServer.Length);
            var response = Encoding.ASCII.GetString(fromServer, 0, bytesRead);
            Console.WriteLine(response);
            var requestT3 = JsonSerializer.Deserialize<RequestT3>(response);
            return requestT3;
        }
    }
}
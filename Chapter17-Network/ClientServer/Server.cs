using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    internal class Server
    {
        private const int bufferSize = 1024;
        private byte[] buffer = new byte[bufferSize];

        public Socket ServerSocket { get; private set; }

        public Server()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var endpoint = new IPEndPoint(IPAddress.Any, 8888);

            try
            {
                ServerSocket.Bind(endpoint);
                ServerSocket.Listen(100);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Ошибка поднятия сервера: {ex.Message}");
            }

            Task.Factory.StartNew(() => Start(), TaskCreationOptions.LongRunning);
        }

        public async Task Start()
        {
            while (true)
            {
                Console.WriteLine($"Ожидание прёма на {ServerSocket.LocalEndPoint}");
                using var socket = await ServerSocket.AcceptAsync();

                Console.WriteLine($"Прием с {socket.RemoteEndPoint}");
                var received = await socket.ReceiveFromAsync(buffer, SocketFlags.None, socket.RemoteEndPoint);
                
                if (received.ReceivedBytes > 0)
                {
                    var recivedMessage = Encoding.UTF8.GetString(buffer, 0, received.ReceivedBytes);
                    Console.WriteLine($"Получено сообщение: {recivedMessage}");

                    var responseMessage = Encoding.UTF8.GetBytes($"Сервер получил '{recivedMessage.Length}' символов");
                    await socket.SendToAsync(responseMessage, SocketFlags.None, received.RemoteEndPoint);

                    Console.WriteLine($"Клиенту {socket.RemoteEndPoint} отправлен ответ");
                }
            }
        }

        public void Stop()
        {
            ServerSocket.Close();
        }
    }
}

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    internal class Client
    {
        private const int bufferSize = 1024;
        private byte[] buffer = new byte[bufferSize];

        public IPEndPoint EndPoint { get; private set; }

        public Client()
        {
            Console.WriteLine("Введите IP адрес сервера:");
            if (!IPAddress.TryParse(Console.ReadLine(), out var address))
            {
                throw new ApplicationException("Не получилось разобрать IP адресс");
            }

            EndPoint = new IPEndPoint(address, 8888);
        }

        private async Task<Socket> Start()
        {
            Console.WriteLine("Подключаемся к серверу...");

            var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                await clientSocket.ConnectAsync(EndPoint);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Ошибка соединения с сервером: {ex.Message}", ex);
            }

            Console.WriteLine($"Подключение к {clientSocket.RemoteEndPoint} установлено");

            return clientSocket;
        }

        public void Stop()
        {
            EndPoint = null;
        }

        public async Task SendMessage(string message)
        {
            using var clientSocket = await Start();

            Console.WriteLine($"Передача сообщения на сервер {clientSocket.RemoteEndPoint}");
            await clientSocket.SendAsync(Encoding.UTF8.GetBytes(message), SocketFlags.None);

            Console.WriteLine($"Прием ответа с сервера {clientSocket.RemoteEndPoint}");
            var length = await clientSocket.ReceiveAsync(buffer, SocketFlags.None);

            if (length > 0)
            {
                var response = Encoding.UTF8.GetString(buffer, 0, length);
                Console.WriteLine($"Принят ответ '{response}' с сервера {clientSocket.RemoteEndPoint}");
            }
        }
    }
}

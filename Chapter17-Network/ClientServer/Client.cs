using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    internal class Client
    {
        private const int bufferSize = 1024;
        private byte[] buffer = new byte[bufferSize];

        public Socket ClientSocket { get; private set; }
        public IPEndPoint EndPoint { get; private set; }

        public Client()
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите IP адрес сервера:");
            if (!IPAddress.TryParse(Console.ReadLine(), out var address))
            {
                throw new ApplicationException("Не получилось разобрать IP адресс");
            }

            EndPoint = new IPEndPoint(address, 8888);
        }

        private async Task Start()
        {
            Console.WriteLine("Подключаемся к серверу...");

            try
            {
                await ClientSocket.ConnectAsync(EndPoint);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Ошибка соединения с сервером: {ex.Message}", ex);
            }

            Console.WriteLine($"Подключение к {ClientSocket.RemoteEndPoint} установлено");
        }

        public void Stop()
        {
            ClientSocket.Close();
        }

        public async Task SendMessage(string message)
        {
            await Start();

            Console.WriteLine($"Передача сообщения на сервер {ClientSocket.RemoteEndPoint}");
            await ClientSocket.SendAsync(Encoding.UTF8.GetBytes(message), SocketFlags.None);

            Console.WriteLine($"Прием ответа с сервера {ClientSocket.RemoteEndPoint}");
            var length = await ClientSocket.ReceiveAsync(buffer, SocketFlags.None);

            if (length > 0)
            {
                var response = Encoding.UTF8.GetString(buffer, 0, length);
                Console.WriteLine($"Принят ответ '{response}' с сервера {ClientSocket.RemoteEndPoint}");
            }

            await ClientSocket.DisconnectAsync(true);
        }
    }
}

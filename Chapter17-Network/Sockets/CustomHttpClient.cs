using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Sockets
{
    internal class CustomHttpClient
    {
        public StringBuilder PageContent { get; private set; } // Для HTML содержимого

        public string Host { get; set; }
        public int Port { get; set; }

        public CustomHttpClient(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public int GetPageStatus(Uri url)
        {
            if (url.Host != Host) throw new ArgumentException("Host not match");
            if (url.Port != Port) throw new ArgumentException("Port not match");

            var address = GetHostAddress(url.Host); // Получаем IP на основе домена
            if (address is null) return (int)CustomHttpStatus.HostNotFound;

            var socket = new Socket(
                AddressFamily.InterNetwork, // Протокол (семейство адресации) - IPv4
                SocketType.Stream, // Тип сокета - Stream с установкой соедиения (т.к. протокол TCP требует этот тип)
                ProtocolType.Tcp); // Протокол - TCP (т.к. HTTP работает поверх него)

            var endpoint = new IPEndPoint(address, url.Port); // Создаем endpoint

            try
            {
                socket.Connect(endpoint); // Пробуем соединистся с endpointом
            }
            catch
            {
                return (int)CustomHttpStatus.CantConnect;
            }

            var command = GetCommand(url); // Формируем запрос

            // Подготавливаем запрос для отправки, HTTP работает с кодировкой ASCII
            var bytesSent = Encoding.ASCII.GetBytes(command);

            socket.Send(bytesSent); // Отправляем запрос

            byte[] buffer = new byte[1024];

            int readBytesCount;
            int result = (int)CustomHttpStatus.Unavailable;
            PageContent = new StringBuilder();

            // Получем данные в буфер пока есть что получать
            while ((readBytesCount = socket.Receive(buffer)) > 0)
            {
                // Конвертируем полученные данные в строку
                // Если буфер заполнен не полностью, то берем из него только заполненную часть
                string resultStr = Encoding.ASCII.GetString(buffer, 0, readBytesCount);

                // Получем статус из ответа из первой строки
                // Она обычно такая: HTTP/1.1 200 OK
                if (PageContent.Length == 0)
                {
                    string statusStr = resultStr.Remove(0, resultStr.IndexOf(' ') + 1);
                    if (!int.TryParse(statusStr[..3], out result))
                    {
                        result = (int)CustomHttpStatus.UnknownCode;
                    }
                }

                PageContent.Append(resultStr); // Кладем строку в результат
            }

            socket.Close(); // Закрываем соединение

            return result;
        }

        private string GetCommand(Uri uri)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"GET {uri.PathAndQuery} HTTP/1.1");
            sb.AppendLine($"Host: {uri.Host}");
            sb.AppendLine("User-Agent: CyD Network Utilities");
            sb.AppendLine("Accept: */*");
            sb.AppendLine("Accept-Language: en-us");
            sb.AppendLine("Accept-Encoding: gzip, deflate");
            sb.AppendLine();

            return sb.ToString();
        }

        // Получение IP по строке хоста
        private IPAddress GetHostAddress(string host)
        {
            IPAddress ip;

            // Сначала проверяем не явлеяется ли хост уже IP адрессом
            if (!IPAddress.TryParse(host, out ip))
            {
                try
                {
                    // Пытаемся получить IP по доменному имени
                    ip = Dns.GetHostEntry(host).AddressList.First();
                }
                catch // Если GetHostEntry выдал исключение или в найденном AddressList нет ни одного элемента
                {
                    return null;
                }
            }

            return ip;
        }
    }
}

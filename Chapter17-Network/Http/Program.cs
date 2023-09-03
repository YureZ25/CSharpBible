using System.Net;
using System.Text;
using System.Web;

string url = "https://www.flenov.info/search/index?search=csharp";

ParseUrl();

// Два метода - один на устаревшем клиенте, другой на актуальном
var body = await GetPageWebClient(false);
//var body = await GetPageHttpClient(false);

Console.WriteLine("Был прочитано такое тело ответа:");
Console.WriteLine(body);

// Тут используется устаревший класс WebRequest
async Task<string> GetPageWebClient(bool useProxy)
{
    HttpWebResponse response;
    try // Тут могут быть различные исключения
    {
        var request = HttpWebRequest.Create(url); // Создаем абстрактный класс WebRequest (в котором по факту будет экземпляр HttpWebRequest)
        
        if (useProxy)
        {
            var proxy = new WebProxy("192.168.0.1", 8080); // Создаем прокси
            proxy.Credentials = new NetworkCredential("userName", "password"); // Задаем креды
            request.Proxy = proxy; // Назначаем запросу, теперь он знает про прокси и будет направлен корректно
        }
        
        response = (HttpWebResponse)await request.GetResponseAsync(); // Тут по факту просиходит загрузка страницы
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка {ex.Message} при запросе к ресурсу {url}.");
        throw;
    }

    var reader = new StreamReader(response.GetResponseStream()); // Берем поток из ответа
    var sb = new StringBuilder();

    string line;
    while ((line = await reader.ReadLineAsync()) != null) // Читаем посточно пока не получим null
    {
        sb.AppendLine(line);
    }

    Console.WriteLine($"Тип данных: {response.ContentType}"); // (достумен из класса WebResponse)
    Console.WriteLine($"Коллекция веб-заголовков: \n{response.Headers}"); // (достумен из класса WebResponse)
    Console.WriteLine($"Кодировка ответа: {response.CharacterSet}");
    Console.WriteLine($"Куки: {string.Join("\n", response.Cookies.Select(c => $"{c.Name}: {c.Value}"))}");
    Console.WriteLine($"Метод запроса: {response.Method}");
    Console.WriteLine($"Версия протокола: {response.ProtocolVersion}");
    Console.WriteLine($"Имя сервера: {response.Server}");
    Console.WriteLine($"Статус ответа: {response.StatusCode}");
    Console.WriteLine($"Описание статуса ответа: {response.StatusDescription}");

    // В ручную диспозим объекты
    response.Close();
    reader.Close();

    return sb.ToString();
}

// На актуальном HttpClient все выгдядит лучше
async Task<string> GetPageHttpClient()
{
    var handler = new HttpClientHandler // Объект настройки HttpClient
    {
        Proxy = new WebProxy("192.168.0.1", 8080),
        DefaultProxyCredentials = new NetworkCredential("userName", "password")
    };

    var client = new HttpClient(handler); // Создаем клиент
    
    var response = await client.GetAsync(url); // Посылаем запрос и получаем ответ

    Console.WriteLine($"Тип данных: {response.Content.Headers.ContentType.MediaType}");
    Console.WriteLine($"Коллекция веб-заголовков: \n{response.Headers}");
    Console.WriteLine($"Кодировка ответа: {response.Content.Headers.ContentType.CharSet}");
    Console.WriteLine($"Куки: {string.Join("\n", response.Headers.GetValues("Set-Cookie"))}");
    Console.WriteLine($"Метод запроса: {response.RequestMessage.Method}");
    Console.WriteLine($"Версия протокола: {response.RequestMessage.Version}");
    Console.WriteLine($"Имя сервера: {response.Headers.Server}");
    Console.WriteLine($"Статус ответа: {response.StatusCode}");

    return await response.Content.ReadAsStringAsync(); // Читаем как строку
}

void ParseUrl()
{
    var uri = new Uri(url);

    Console.WriteLine($"Хост: {uri.Host}");
    Console.WriteLine($"Путь к странице на хосте: {uri.AbsolutePath}");
    Console.WriteLine($"Путь с параметрами: {uri.PathAndQuery}");
    Console.WriteLine($"Параметры: {uri.Query}");
    Console.WriteLine($"Пусть к странице по частям: {string.Join(", ", uri.Segments.Select(s => $"[\"{s}\"]"))}");
    
    // Параметры легко можно спарсить с помощью этого хелпера
    //Console.WriteLine($"Параметры по частям: {HttpUtility.ParseQueryString(uri.Query)}");
    // Но если сильно хочется, можно создать свою имплементацию
    Console.WriteLine($"Параметры по частям: {string.Join(", ", ParseQuery(uri.Query).Select(p => $"[\"{p.Key}\"]: \"{p.Value}\""))}");

    Dictionary<string, string> ParseQuery(string query)
    {
        var queryParams = new Dictionary<string, string>();

        query = query.Substring(1, query.Length - 1);

        foreach (var param in query.Split('&'))
        {
            var paramKeyAndValue = param.Split('=');
            queryParams.Add(paramKeyAndValue[0], paramKeyAndValue[1]);
        }

        return queryParams;
    }
}

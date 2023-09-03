using System.Net;
using System.Text;

// Два метода - один на устаревшем клиенте, другой на актуальном
var body = await GetPageWebClient();
//var body = await GetPageHttpClient();

Console.WriteLine("Был прочитано такое тело ответа:");
Console.WriteLine(body);

// Тут используется устаревший класс WebRequest
async Task<string> GetPageWebClient()
{
    string url = "http://flenov.info";

    HttpWebResponse response;
    try // Тут могут быть различные исключения
    {
        var request = HttpWebRequest.Create(url); // Создаем абстрактный класс WebRequest (в котором по факту будет экземпляр HttpWebRequest)
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
    string url = "http://flenov.info";

    var client = new HttpClient(); // Создаем клиент
    
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
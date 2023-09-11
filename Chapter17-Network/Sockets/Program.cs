using Sockets;

var client = new CustomHttpClient("flenov.info", 80);

int status = client.GetPageStatus(new Uri("http://flenov.info"));
Console.WriteLine($"Статус запроса: {status}");

Console.WriteLine("Содержание страницы:");
Console.WriteLine(client.PageContent);


Console.WriteLine("Введите название файла для создания/открытия:");
var fileName = Console.ReadLine();

var list = GetListFromFile(fileName, out var path);

Console.WriteLine("Содержимое файла:");
foreach (var item in list)
{
    Console.WriteLine(item);
}

Console.WriteLine("Добавте данные. Для выхода введите q");
while (true)
{
    var input = Console.ReadLine();
    if (input == "q") break;
    list.Add(input);
}

Console.WriteLine("Сохоанить данные? (y/n)");
if (Console.ReadLine() == "y")
{
    SaveListToFile(path, list);
}

IList<string> GetListFromFile(string? fileName, out string path)
{
    if (string.IsNullOrEmpty(fileName)) throw new ArgumentException("Имя файла не должно быть пустым");

    path = Path.Combine(Directory.GetCurrentDirectory(), fileName + ".list");

    if (File.Exists(path))
    {
        return File.ReadAllLines(path).ToList();
    }
    else
    {
        return new List<string>();
    }
}

void SaveListToFile(string path, IList<string> list)
{
    using (var sw = File.CreateText(path))
    {
        foreach (var item in list)
        {
            sw.WriteLine(item);
        }
        // При использовании using не нужно вызывать этот метод
        //sw.Close();
    }
}
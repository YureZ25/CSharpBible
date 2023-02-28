
string sample = "Stop war!";

Console.WriteLine($"Строка содержит \"war\" = {sample.Contains("war")}");

Console.WriteLine(string.Format("Мощность машины {0} л.с.", 115));

Console.WriteLine($"Ищем начало \"war\". Индекс начала = {sample.IndexOf("war")} ");

Console.WriteLine(sample.Insert(8, " on Donbass"));

Console.WriteLine(sample.PadLeft(sample.Length + 5));

Console.WriteLine(sample.Remove(4, 4));

Console.WriteLine(sample.Replace("war", "USA"));

Console.WriteLine(sample.ToUpper());

Console.WriteLine($"Don't {sample.Substring(0, 4).ToLower()} me now");


Console.WriteLine();
Console.WriteLine("C:\\Windows\\system32\\filename.txt");
Console.WriteLine(@"C:\\Windows\\system32\\filename.txt");
Console.WriteLine(@"Multiline 
                        string");
Console.WriteLine("Введите строку:");
Console.WriteLine($"Строка пуста = {string.IsNullOrEmpty(Console.ReadLine())}");
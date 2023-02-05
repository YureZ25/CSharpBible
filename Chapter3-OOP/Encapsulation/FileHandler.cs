namespace Encapsulation
{
    internal class FileHandler
    {
        private int handler; // Представим, что это указатель на строку в файле

        // Смысл в скрытии деталей реализации от внешних классов
        // И объединении данных и методов (когда мы не против хранить состояние)
        public FileHandler(string fileName)
        {
            Console.WriteLine($"Открываем файл с именем {fileName}");
            handler = 5;
        }

        public string ReadLine()
        {
            Console.WriteLine($"Прочитана {handler} сторока");

            return $"Наша {handler} строка";
        }
    }
}

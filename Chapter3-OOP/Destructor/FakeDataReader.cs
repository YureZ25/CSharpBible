namespace Destructor
{
    internal class FakeDataReader
    {
        private readonly string filePath;

        public FakeDataReader(string filePath)
        {
            this.filePath = filePath;
            Console.WriteLine($"Вызов конструктора. Месторасположение файла: {this.filePath}");
        }

        ~FakeDataReader()
        {
            Console.WriteLine($"Вызов деструктора. Месторасположение файла: {this.filePath}");
        }
    }
}

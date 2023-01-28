namespace Static
{
    internal class Sheep
    {
        static int Count { get; set; }
        static Dictionary<int, Sheep> SheepDict { get; set; } = new Dictionary<int, Sheep>();

        static Sheep()
        {
            Count = 5;
            Console.WriteLine("Вызыван статический конструктор, начинаем считать овец с 5");
        }

        public static int GetCount()
        {
            return Count;
        }

        public static void ShowAll()
        {
            Console.WriteLine("Полный список овец");
            foreach (var (index, sheep) in SheepDict)
            {
                Console.WriteLine($"Овца {sheep.SheepName} под номером {index}");
            }
            Console.WriteLine();
        }

        public int SheepIndex { get; set; }
        public string SheepName { get; set; }

        public Sheep()
        {
            SheepIndex = 0;
            SheepName = string.Empty;
        }

        public Sheep(string name)
        {
            SheepIndex = ++Count;
            SheepName = name;

            SheepDict.Add(SheepIndex, this);
            Console.WriteLine($"Создана новая овца {SheepName}");
        }

        public int GetSheepIndex()
        {
            if (SheepDict.TryGetValue(SheepIndex, out var sheep))
            {
                return SheepIndex;
            }
            throw new Exception($"Овца по индексу {SheepIndex} не найдена");
        }
    }
}


object syncObj = new(); // Объект синхронизации

for (int i = 0; i < 5; i++)
{
    var t = new Thread(() => ThreadFunc()) // Создаем поток с именем
    {
        Name = $"Поток {i}"
    };
    t.Start(); // Запускаем
}

void ThreadFunc()
{
    lock (syncObj) // Lock секция гарантирует выполнение только этого кода в моменте
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} - {i}");
            Thread.Sleep(100);
        }
    }
}

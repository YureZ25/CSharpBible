
ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);
ThreadPool.GetAvailableThreads(out var availableWorkerThreads, out var availableCompletionPortThreads);
ThreadPool.GetMinThreads(out var minWorkerThreads, out var minCompletionPortThreads);

Console.WriteLine($"Максимальное кол-во одновременно выполняемых потоков в пуле: {maxWorkerThreads}");
Console.WriteLine($"Минимальное кол-во готовых к выполнению потоков в пуле: {minWorkerThreads}");
Console.WriteLine($"Кол-во свободных потоков в пуле {availableWorkerThreads}");
Console.WriteLine($"Кол-во существующих потоков в пуле {ThreadPool.ThreadCount}");

for (int i = 0; i < 15; i++)
{
    ThreadPool.QueueUserWorkItem(FactFunc, i);

    // Можно использовать generic перегрузку
    //ThreadPool.QueueUserWorkItem(FactFunc, i, true);
}

Console.WriteLine($"Кол-во существующих потоков в пуле {ThreadPool.ThreadCount}");

// Ожидание ввода необходимо, т.к. все потоки из пула фоновые
Console.ReadKey();

// Функция расчета факториала
void FactFunc(object? state)
{
    var num = (int?)state;
    var result = 1;
    for (int i = 2; i <= num; i++)
    {
        result *= i;
    }
    Console.WriteLine($"Факториал {num} = {result}");
}
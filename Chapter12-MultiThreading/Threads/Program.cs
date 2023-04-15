Thread thread;

Console.WriteLine("Хотите задать количество операций доп потока? (да - digit/нет - any key)");
if (int.TryParse(Console.ReadLine(), out var value))
{
    // Создаем объект потока, в конструктор передаем делегат ParamThreadStart - void(object) метод
    thread = new Thread(ParamThreadProc);

    // Если поток фоновый - завершение основного потока приведет к завершению дополнительного
    Console.WriteLine("Сделать дополнительный поток фоновым? (y/n)");
    if (Console.ReadLine() == "y")
        thread.IsBackground = true;

    thread.Start(value); // Даем команду запустить поток, но не гарантирует этого
    Console.WriteLine($"Поставили поток {thread.ManagedThreadId} на запуск. Текущее состояние: {thread.ThreadState}");

    // Альтернативный запуск с несколькими параметрами
    //thread = new Thread(() => ParamThreadProc(value));
    //thread.Start();
}
else
{
    // Создаем объект потока, в конструктор передаем делегат ThreadStart - void() метод
    thread = new Thread(ThreadProc);

    // Можно написать передачу делегата и через new
    //var thread = new Thread(new ThreadStart(ThreadProc));

    // Если поток фоновый - завершение основного потока приведет к завершению дополнительного
    Console.WriteLine("Сделать дополнительный поток фоновым? (y/n)");
    if (Console.ReadLine() == "y")
        thread.IsBackground = true;

    thread.Start(); // Даем команду запустить поток, но не гарантирует этого
    Console.WriteLine($"Поставили поток {thread.ManagedThreadId} на запуск. Текущее состояние: {thread.ThreadState}");
}

// Проверика ассинхроннстм выполнения потока - ввод должен быть активен
string input;
do
{
	input = Console.ReadLine() ?? string.Empty;
	Console.WriteLine(input);
} while (input != "q");


// Метод который будет запущен в доп потоке
void ThreadProc()
{
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine($"Это работает дополнительный поток #{i}");
		Thread.Sleep(1000); // Некая долгая синхронная операция
	}
}

// Метод с параметами, который будет запущен в доп потоке
void ParamThreadProc(object? obj)
{
    var count = (int?)obj ?? 1;

    for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"Это работает дополнительный поток #{i}");
        Thread.Sleep(1000); // Некая долгая синхронная операция
    }
}

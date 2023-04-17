
int factorialToCalculate = 11;

Task<int> factorialTask = Task.FromResult(0); // Если результат уже есть, можно отдать его так

// Можно ипользовать Run для запуска задач описанных в анонимной функции
// Однако слишком продолжительные задачи так запускать не рекомендуется
// Потому что для этого используются потоки из thread pool (то же самое, что QueueUserWorkItem())
factorialTask = Task.Run(() =>
{
	int result = 1;
	for (int i = 1; i < factorialToCalculate; i++)
	{
		result *= i;
		Task.Delay(10).Wait();
	}
	return result;
});

// Можно исоползовать для относительно продолжительных задач, т.к. с LongRunning опцией создается новый поток
// Но LongRunning нельзя использовать с await, т.е. новый поток будет уничтожен после первого await
//factorialTask = Task.Factory.StartNew(() =>
//{
//    int result = 1;
//    for (int i = 1; i < factorialToCalculate; i++)
//    {
//        result *= i;
//        Task.Delay(10).Wait();
//    }
//    return result;
//}, TaskCreationOptions.LongRunning);

// Для действительно продолжительных задач лучше использовать new Thread с IsBackground = true

// Так проверять не стоит, просто для примера. Использовать await.
while (factorialTask.Status != TaskStatus.RanToCompletion)
{
    Console.WriteLine($"Статус - {factorialTask.Status}");
	Task.Delay(100).Wait();
}

Console.WriteLine($"Статус - {factorialTask.Status}");
Console.WriteLine($"Результат = {factorialTask.Result}");
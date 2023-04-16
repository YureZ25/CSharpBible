
int factorialToCalculate = 11;

var factorialTask = Task.Run(() =>
{
    int result = 1;
	for (int i = 1; i < factorialToCalculate; i++)
	{
		result *= i;
		Task.Delay(10).Wait();
	}
	return result;
});

while (factorialTask.Status != TaskStatus.RanToCompletion)
{
    Console.WriteLine($"Статус - {factorialTask.Status}");
	Task.Delay(100).Wait();
}

Console.WriteLine($"Статус - {factorialTask.Status}");
Console.WriteLine($"Результат = {factorialTask.Result}");

// Выводим данные о дате и времени сейчас
DateTime now = DateTime.Now;
PrintDate(now);
// Вводим все составляющие даты в виде чисел
int year = GetNumberInput("год");
int month = GetNumberInput("месяц");
int day = GetNumberInput("день");
int hour = GetNumberInput("час");
int minute = GetNumberInput("минуты");
// Создаем объект с помощью одной из перегрузок конструктора
DateTime dt = new DateTime(year, month, day, hour, minute, 0);
// Выводим данные об этой дате
PrintDate(dt);
// Вычитаем 3 дня из даты
dt = dt.Add(TimeSpan.FromDays(-3));
PrintDate(dt); 

int GetNumberInput(string inputMessage)
{
	while (true)
	{
		Console.WriteLine($"Введите {inputMessage}");
		if (int.TryParse(Console.ReadLine(), out int input))
		{
			return input;
		}
		Console.WriteLine("Неверное значение");
	}
}

void PrintDate(DateTime dt)
{
    Console.WriteLine($"День недели: {dt.DayOfWeek}");
    Console.WriteLine($"День недели #{(int)dt.DayOfWeek}");
    Console.WriteLine($"Время: {dt.TimeOfDay}");
    Console.WriteLine($"День в году: {dt.DayOfYear}");
    Console.WriteLine($"ToString: {dt}");
    Console.WriteLine($"Date.ToString: {dt.Date}");
    Console.WriteLine($"ToShortDateString: {dt.ToShortDateString()}");
    Console.WriteLine($"ToLongDateString: {dt.ToLongDateString()}");
    Console.WriteLine($"ToShortTimeString: {dt.ToShortTimeString()}");
    Console.WriteLine($"ToLongTimeString: {dt.ToLongTimeString()}");
    Console.WriteLine();
}
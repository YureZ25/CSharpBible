Console.Title = "Радужная консолька";

foreach (var color in Enum.GetValues<ConsoleColor>())
{
    // Расчитываем левый отступ - делим ширину на 2, чтобы получить середину
    Console.CursorLeft = (Console.BufferWidth - color.ToString().Length) / 2;
    Console.CursorTop = 10; // Отступаем сверху
    Console.ForegroundColor = color; // Устанавливаем цвет шрифта
    Console.WriteLine(color); // Выводим строковое представление цвета
    Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Задержка
    Console.Clear(); // Очистка
}


int[] test = { 10, 20, 1, 6, 15 };

Console.WriteLine("Исходный массив: ");
Print(test);

Console.WriteLine("Отсортированный: ");
Array.Sort(test);
Print(test);

Console.WriteLine("Реверсированный: ");
Array.Reverse(test);
Print(test);

Console.WriteLine("Очистка нескольких элементов:");
Array.Clear(test, 2, 2);
Print(test);

Console.WriteLine("Изменение размера:");
Array.Resize(ref test, 3);
Print(test);

Console.WriteLine("Бинарный поиск:");
int foundIndex = Array.BinarySearch(test, 15);
Console.WriteLine($"Индекс искомого элемента = {foundIndex}");

void Print(int[] array)
{
    foreach (int i in array) Console.Write(i + " ");
    Console.WriteLine();
}
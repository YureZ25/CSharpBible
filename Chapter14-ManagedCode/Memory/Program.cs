using System.Runtime.InteropServices;

int[] srcArray = { 10, 20, 5, 2, 54, 9 };

foreach (var i in srcArray)
{
    Console.WriteLine($"Исходное значение: {i}");
}

Console.WriteLine("\nВыделение памяти в стеке:");

unsafe
{
    // Выделяем память в стеке для массива из n int элементов
    // stackalloc возвращает указатель на начало выделенной области
    int* tripleArray = stackalloc int[srcArray.Length];

    for (int i = 0; i < srcArray.Length; i++)
    {
        // Благодаря арифметике указателей (элементы массива стоят в памяти по порядку) мы можем обращатся к ним
        if (i < srcArray.Length / 2)
        {
            tripleArray[i] = 3 * srcArray[i]; // по индексу
        }
        else
        {
            *(tripleArray + i) = 3 * srcArray[i]; // или используя арифметику указателей на прямую
        }

        Console.WriteLine($"Значение: {tripleArray[i]}");
    }

    // Как и для управляемого когда, память выделенная stackalloc освободится при выходе из метода
}

Console.WriteLine("\nПолучение указателя на управляемый объект:");

Point point = new Point(3, 17);

var handle = GCHandle.Alloc(point);

var pointAddr = GCHandle.ToIntPtr(handle);

unsafe
{
    var pointPtr = (Point*)pointAddr.ToPointer();

    Console.WriteLine($"Произвдение координат: {pointPtr->x * pointPtr->y}");
}

handle.Free();

Console.WriteLine("\nФиксирование объекта в куче:");

unsafe
{
    fixed (int* powTwo = srcArray)
    {
        for (int i = 0; i < srcArray.Length; i++)
        {
            powTwo[i] = (int)Math.Pow(*(powTwo + i), 2); 
        }
    }
}

foreach (var i in srcArray)
{
    Console.WriteLine($"Типо исходное значение: {i}");
}

public class Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}



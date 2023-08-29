
short x = 10; // Выделяем и заполняем память для переменной в стеке в управляемом коде

unsafe
{
    short* ptr = &x; // Берем указатель/адрес в памяти (&) и сохраняем в переменную указателя

    Console.WriteLine($"Адрес: {(int)ptr}"); // Для вывода приводим к числу
    Console.WriteLine($"Значение по указанному адресу: {*ptr}"); // Для получения данных - разименовываем (*)

    ptr++; // Инкремент указателя - сдвиг в памяти на размер типа в байтах (здесь плюс 2)
    Console.WriteLine($"Размер типа {x.GetType()} равен {sizeof(short)}");
    Console.WriteLine($"Размер указателя типа {x.GetType()} равен {sizeof(short*)}"); // Здесь значение будет зависеть от битности системы

    Console.WriteLine($"Адрес: {(int)ptr}");
    Console.WriteLine($"Значение по указанному адресу: {*ptr}");
}

Point point = new Point { X = 3, Y = 29 };

unsafe
{
    Point* ptr = &point; // В стеке можно спокойно делать дела с указателями

    Console.WriteLine($"Адрес: {(int)ptr}");
    Console.WriteLine($"Значение по указанному адресу: {ptr->ToString()}"); // Вызываем метод по указателю (->)
}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
        return $"{X}-{Y}";
    }
}

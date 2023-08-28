
short x = 10; // Выделяем и заполняем память для переменной в стеке в управляемом коде

unsafe
{
    short* ptr = &x; // Берем указатель/адрес в памяти (&) и сохраняем в переменную указателя

    Console.WriteLine($"Адрес: {(int)ptr}"); // Для вывода приводим к числу
    Console.WriteLine($"Значение по указанному адресу: {*ptr}"); // Для получения данных - разименовываем (*)

    ptr++; // Инкремент указателя - сдвиг в памяти на размер типа в байтах (здесь плюс 2)

    Console.WriteLine($"Адрес: {(int)ptr}");
    Console.WriteLine($"Значение по указанному адресу: {*ptr}");
}

Point point = new Point { X = 3, Y = 29 };

unsafe
{
#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
    Point* ptr = &point; // Так делать не желательно
#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

    Console.WriteLine($"Адрес: {(int)ptr}");
    Console.WriteLine($"Значение по указанному адресу: {ptr->ToString()}"); // Вызываем метод по указателю (->)
}

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
        return $"{X}-{Y}";
    }
}

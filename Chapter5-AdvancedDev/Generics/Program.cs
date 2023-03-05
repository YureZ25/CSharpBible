// Дженерики еще называют шаблонами (template) - термин пришел из С++
// T - сокрашщение от template, а не от type

// Во многих ситуациях тип шаблона может быть определен по аргуметам метода
Console.WriteLine(GenericConcat("Hello", "World"));
Console.WriteLine(GenericConcat(10, 18));
Console.WriteLine(GenericConcat<string>("Hello", Convert.ToString(37)));
Console.WriteLine();

// Generic метод
string GenericConcat<T>(T firstValue, T secondValue)
{
    return firstValue?.ToString() + secondValue?.ToString();
}

// При создании класса обязательно надо указать тип
var genericArray = new GenericStaticArray<int>(5);
genericArray.Add(15);
genericArray.Add(46);
genericArray.Add(42);
genericArray.Add(27);

for (int i = 0; i < genericArray.Count(); i++)
{
    Console.WriteLine(genericArray.Get(i));
}

// Generic класс
class GenericStaticArray<T>
{
    T[] _array;
    int _capasity;
    int _len;

    public GenericStaticArray(int capasity)
    {
        _array = new T[capasity];
        _capasity = capasity;
        _len = 0;
    }

    public void Add(T value)
    {
        if (_len + 1 > _capasity)
        {
            throw new OverflowException();
        }

        _array[_len++] = value;
    }

    public T? Get(int index)
    {
        if (index < _len && index >= 0)
            return _array[index];
        else
            return default;
    }

    public int Count()
    {
        return _len;
    }
}

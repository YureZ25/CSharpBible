
int integerVal = 42;
long longVal = integerVal;
Console.WriteLine($"Не явное приведение(cast) числа {integerVal} типа {integerVal.GetType()} " +
    $"в число {longVal} типа {longVal.GetType()}");

double doubleVal = 14.43;
float floatVal = (float)doubleVal;
Console.WriteLine($"Явное приведение(cast) числа {doubleVal} типа {doubleVal.GetType()} " +
    $"в число {floatVal} типа {floatVal.GetType()}");
Console.WriteLine();


object integerObj = integerVal;
Console.WriteLine($"Запаковка(boxing) числа {integerVal} в объект {integerObj}");
var unboxLong = (long)(int)integerObj; // Ньюанс - распаковать можно только в тот же тип, что и запаковывали и только потом приводить
Console.WriteLine($"Распаковка(unboxing) объекта {integerObj} в число {unboxLong}");
Console.WriteLine();

while (true)
{
    Console.WriteLine("Введите целое число");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out var v))
    {
        Console.WriteLine($"Преобразование(converting) строки {input} в целое число {v} прощло успешно.");
        break;
    }

    Console.WriteLine("Не-а, ввод не корректный, попробуйте ещё раз. (И так до скончания времен...)");
}



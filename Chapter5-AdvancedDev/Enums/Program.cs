
Console.WriteLine("Enum names");
foreach (string enumName in Enum.GetNames<EnumTest.MyColors>())
    Console.WriteLine(enumName);

Console.WriteLine("Enum names with values");
foreach (var enumValue in Enum.GetValues<EnumTest.MyColors>())
    Console.WriteLine(enumValue + " - " + (int)enumValue);

Console.WriteLine("Выберите цвет по умолчанию");
string? input = Console.ReadLine();
if (Enum.TryParse<EnumTest.MyColors>(input, ignoreCase: true, out var output))
{
    EnumTest.myDefaultColor = output;
    Console.WriteLine($"Выбрали цвет {output} - {(int)output}");
}
else
{
    Console.WriteLine("Ввели какую-то несуразицу...");
}

Console.WriteLine("Введите значение цвета по умолчанию");
input = Console.ReadLine();
if (int.TryParse(input, out int intOutput))
{
    EnumTest.myDefaultColor = (EnumTest.MyColors)intOutput;
    Console.WriteLine($"Выбрали цвет {(EnumTest.MyColors)intOutput} - {intOutput}");
}
else
{
    Console.WriteLine("Ввели какую-то несуразицу...");
}

class EnumTest
{
    // Можно определять перечисления и как вложенные (nested) в класс, если они будут использоваться в основном локально
    public enum MyColors
    {
        White = 0,
        Red = 100,
        Green = 200,
        Blue = 300,
    }

    public static MyColors myDefaultColor = MyColors.Red;
}
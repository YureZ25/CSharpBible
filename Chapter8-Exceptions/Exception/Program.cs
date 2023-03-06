
while (true)
{
    Console.WriteLine("Введите число (q чтобы выйти)");

    var input = Console.ReadLine();

    if (input == "q") break;

    try
    {
        var i = Convert.ToInt32(input);
        Console.WriteLine($"Вы ввели {i}");
    }
    catch (FormatException)
    {
        Console.WriteLine($"Вы ввели не корректное число '{input}'");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
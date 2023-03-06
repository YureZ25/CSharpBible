
int x = 1000000;
int y = 3000;
int z = 0;

try
{
    z = checked(x * y);

    checked
    {
        z = x * y;
    }
}
catch (OverflowException)
{
    Console.WriteLine("Значение вышло за пределы");
}

Console.WriteLine($"Значение: {z}");
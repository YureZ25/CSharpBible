
int[,] multirank = new int[2, 3] { { 5, 9, 4 }, { 5, 3, 8 } };

int rows = multirank.GetUpperBound(0) + 1;
int colums = multirank.GetUpperBound(1) + 1; // или multirank.Length / rows

Console.WriteLine("Двумерный массив:");
for (int i = 0; i < rows; i++)
{
	for (int j = 0; j < colums; j++)
	{
        Console.Write($"{multirank[i, j]} \t");
    }
    Console.WriteLine();
}
Console.WriteLine();


int[][] jagged = new int[10][];

for (int i = 0; i < jagged.Length; i++)
{
    jagged[i] = new int[i];
}

for (int i = 0; i < jagged.Length; i++)
{
    for (int j = 0; j < jagged[i].Length; j++)
    {
        jagged[i][j] = j;
    }
}

Console.WriteLine("Зубчатый массив:");
for (int i = 0; i < jagged.Length; i++)
{
    for (int j = 0; j < jagged[i].Length; j++)
    {
        Console.Write($"{jagged[i][j]} \t");
    }
    Console.WriteLine();
}
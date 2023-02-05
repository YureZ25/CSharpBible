Figure rect;
rect = new Circle { PositionX = 6, PositionY = 3, Radius = 7 };
rect.Draw();

rect = new Rectangle { PositionX = 4, PositionY = 22, Height = 4, Width = 8 };
rect.Draw();

Console.SetCursorPosition(0, 30);

abstract class Figure
{
    public required int PositionX { get; set; }
    public required int PositionY { get; set; }

    public abstract void Draw();
}

class Rectangle : Figure
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        int x = PositionX;
        int y = PositionY;
        Console.SetCursorPosition(x, y);

        for (int i = x; i < x + Width; i++)
        {
            Console.SetCursorPosition(i, y);
            Console.Write("—");
        }

        x += Width;
        y++;

        for (int i = y; i < y + Height; i++)
        {
            Console.SetCursorPosition(x, i);
            Console.Write("|");
        }

        y += Height;
        x--;

        for (int i = x; i > x - Width; i--)
        {
            Console.SetCursorPosition(i, y);
            Console.Write("-");
        }

        x -= Width;
        y--;

        for (int i = y; i > y - Height; i--)
        {
            Console.SetCursorPosition(x, i);
            Console.Write("|");
        }
    }
}

class Circle : Figure
{
    public int Radius { get; set; }

    public override void Draw()
    {
        var list = new List<(int x, int y)>();

        for (int x = -Radius; x <= Radius; x++)
        {
            int y = (int)Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(x, 2));
            list.Add((x + Radius + 1, y + Radius + 1));
            list.Add((x + Radius + 1, -y + Radius + 1));
        }

        foreach (var (x, y) in list)
        {
            Console.SetCursorPosition(x + PositionX, y + PositionY);
            Console.Write("*");
        }
    }
}
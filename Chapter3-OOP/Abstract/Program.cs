Figure rect;
rect = new Rectangle { PositionX = 4, PositionY = 6, Height = 4, Width = 8 };
rect.Draw();

rect = new Circle { PositionX = 6, PositionY = 18, Radius = 3 };
rect.Draw();

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
        //Console.SetCursorPosition(PositionX, PositionY);
        Console.SetCursorPosition(0, PositionY);

        double r_in = Radius - 0.4;
        double r_out = Radius + 0.4;

        for (double y = Radius; y >= -Radius; y--)
        {
            for (double x = -Radius; x < r_out; x += 0.5)
            {
                double val = Math.Pow(x, 2) + Math.Pow(y, 2);
                if (val >= Math.Pow(r_in, 2) && val <= Math.Pow(r_out, 2))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
namespace OperatorsOverride
{
    internal class MyPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public MyPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static MyPoint operator + (MyPoint left, MyPoint right)
        {
            return new MyPoint(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static MyPoint operator - (MyPoint left, MyPoint right)
        {
            return new MyPoint(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static MyPoint operator / (MyPoint left, int right)
        {
            return new MyPoint(left.X / right, left.Y/ right, left.Z / right);
        }

        public static MyPoint operator * (MyPoint left, int right)
        {
            return new MyPoint(left.X * right, left.Y * right, left.Z * right);
        }

        public static explicit operator MyPoint(PersonPosition personPosition)
        {
            return new MyPoint(personPosition.X, personPosition.Y, personPosition.Z);
        }

        public override string ToString()
        {
            return $"[{X},{Y},{Z}]";
        }
    }
}

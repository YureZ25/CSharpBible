namespace OperatorsOverride
{
    internal class MyLine
    {
        public MyPoint Start { get; set; }
        public MyPoint End { get; set; }

        private double Length => Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2) + Math.Pow(End.Z - Start.Z, 2));

        public MyLine(MyPoint start, MyPoint end)
        {
            Start = start;
            End = end;
        }

        public static bool operator < (MyLine left, MyLine right)
        {
            return left.Length < right.Length;
        }

        public static bool operator > (MyLine left, MyLine right)
        {
            return left.Length > right.Length;
        }
    }
}

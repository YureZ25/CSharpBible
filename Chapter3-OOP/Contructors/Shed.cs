namespace Contructors
{
    internal class Shed
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }

        public Shed(int width, int length, int height)
        {
            Width = width;
            Length = length;
            Height = height;
        }

        public double GetVolume()
        {
            return Width * Length * Height;
        }
    }
}

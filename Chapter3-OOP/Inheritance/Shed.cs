namespace Inheritance
{
    internal class Shed : Building
    {
        public Shed() : this(1, 1, 1)
        {

        }

        public Shed(int width, int length, int height)
        {
            Width = width;
            Length = length;
            Height = height;
        }

        public int GetVolume()
        {
            return Width * Length * Height;
        }
    }
}

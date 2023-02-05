namespace Inheritance
{
    internal class Building
    {
        private int _width;
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Length { get; set; }
        public int Height { get; set; }
    }
}

using System.Text.RegularExpressions;
using System.Xml;

namespace XmlFiles
{
    internal class Rose
    {
        public string Name { get; private set; } = string.Empty;

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rose() { }

        public Rose(string name, int x, int y, int width, int height)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public static void SaveToFile(XmlTextWriter tw, Rose rose)
        {
            tw.WriteStartElement(nameof(Rose));
            tw.WriteAttributeString(nameof(Name), rose.Name);
            tw.WriteAttributeString(nameof(X), rose.X.ToString());
            tw.WriteAttributeString(nameof(Y), rose.Y.ToString());
            tw.WriteAttributeString(nameof(Width), rose.Width.ToString());
            tw.WriteAttributeString(nameof(Height), rose.Height.ToString());
            tw.WriteEndElement();
        }

        public static Rose ReadFromFile(XmlTextReader tr)
        {
            var rose = new Rose();

            try
            {
                rose.Name = tr?.GetAttribute(nameof(Name)) ?? string.Empty;
                rose.X = Convert.ToInt32(tr?.GetAttribute(nameof(X)));
                rose.Y = Convert.ToInt32(tr?.GetAttribute(nameof(Y)));
                rose.Width = Convert.ToInt32(tr?.GetAttribute(nameof(Width)));
                rose.Height = Convert.ToInt32(tr?.GetAttribute(nameof(Height)));
            }
            catch
            {

            }

            return rose;
        }

        public static IEnumerable<Rose> GetDefaultList()
        {
            return new Rose[]
            {
                new("Аня", 3, 64, 23, 94),
                new("Таня", 64, 372, 62, 34),
                new("Катя", 71, 9, 73, 396),
                new("Наташа", 26, 64, 86, 582),
            };
        }

        public override string ToString()
        {
            return $"Название: {Name}, Ширина: {Width}, Высота: {Height}, X: {X}, Y: {Y}";
        }
    }
}

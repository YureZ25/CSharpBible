using System.Text;
using System.Xml;

namespace XmlFiles
{
    internal class RosesPlant
    {
        private static string FilePath => Path.GetFullPath("RosesPlant.xml"); 

        public static void SaveProject(IEnumerable<Rose> roses)
        {
            using var fs = new FileStream(FilePath, FileMode.Create);
            using var xmlOut = new XmlTextWriter(fs, Encoding.Unicode);
            xmlOut.Formatting = Formatting.Indented;

            xmlOut.WriteStartDocument();
            xmlOut.WriteComment("Этот файл создан для примера");
            xmlOut.WriteComment("Автор: YureZ");

            xmlOut.WriteStartElement(nameof(RosesPlant));
            xmlOut.WriteAttributeString("Version", "1");

            foreach (var rose in roses)
            {
                Rose.SaveToFile(xmlOut, rose);
            }

            xmlOut.WriteEndElement();
            xmlOut.WriteEndDocument();

            Console.WriteLine($"Проект записан в файл по пути '{FilePath}'");

            // Эти методы нужно вызывать если не использовать using
            // xmlOut.Close();
            // fs.Close();
        }

        public static IEnumerable<Rose> OpenProject()
        {
            using var fs = new FileStream(FilePath, FileMode.Open);
            using var xmlIn = new XmlTextReader(fs);
            xmlIn.WhitespaceHandling = WhitespaceHandling.None;

            xmlIn.MoveToContent();

            if (xmlIn.Name != nameof(RosesPlant)) throw new ArgumentException($"Не найден элемент {nameof(RosesPlant)}");

            var version = xmlIn.GetAttribute(0);
            Console.WriteLine($"Открыт элемент {nameof(RosesPlant)} версии {version}");

            do
            {
                if (!xmlIn.Read()) throw new ArgumentException("Ошибка чтения");

                if (xmlIn.NodeType == XmlNodeType.EndElement
                    && xmlIn.Name == nameof(RosesPlant)) break;

                if (xmlIn.NodeType == XmlNodeType.EndElement) continue;

                if (xmlIn.Name == nameof(Rose))
                {
                    yield return Rose.ReadFromFile(xmlIn);
                }

            } while (!xmlIn.EOF);

        }
    }
}

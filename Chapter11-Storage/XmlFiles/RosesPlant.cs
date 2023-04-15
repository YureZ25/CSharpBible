using System.Text;
using System.Xml;

namespace XmlFiles
{
    internal class RosesPlant
    {
        private static string FilePath => Path.GetFullPath("RosesPlant.xml"); 

        public static void SaveProject(IEnumerable<Rose> roses)
        {
            using var fs = new FileStream(FilePath, FileMode.Create); // Создаем обычный File Stream (или любой Stream)
            using var xmlOut = new XmlTextWriter(fs, Encoding.Unicode); // Используем Sream как провайдер
            xmlOut.Formatting = Formatting.Indented; // Для читаемости

            xmlOut.WriteStartDocument();
            xmlOut.WriteComment("Этот файл создан для примера"); // Не считается контентом
            xmlOut.WriteComment("Автор: YureZ");

            xmlOut.WriteStartElement(nameof(RosesPlant)); // Удобно использовать имена классов
            xmlOut.WriteAttributeString("Version", "1");

            foreach (var rose in roses)
            {
                // Инкапсулируем запись в класс Розы, но в идеале выделить эту ответственность в отдельную сущность
                Rose.SaveToFile(xmlOut, rose);
            }

            xmlOut.WriteEndElement(); // Закрываем RosesPlant
            xmlOut.WriteEndDocument();

            Console.WriteLine($"Проект записан в файл по пути '{FilePath}'");

            // Эти методы нужно вызывать если не использовать using
            // xmlOut.Close();
            // fs.Close();
        }

        public static IEnumerable<Rose> OpenProject()
        {
            using var fs = new FileStream(FilePath, FileMode.Open); // Открываем только существующий файл
            using var xmlIn = new XmlTextReader(fs);
            xmlIn.WhitespaceHandling = WhitespaceHandling.None; // Игнорируем пробелы

            xmlIn.MoveToContent();

            if (xmlIn.Name != nameof(RosesPlant)) throw new ArgumentException($"Не найден элемент {nameof(RosesPlant)}");

            var version = xmlIn.GetAttribute(0); // Берем перый аттрибут у RosesPlant
            Console.WriteLine($"Открыт элемент {nameof(RosesPlant)} версии {version}");

            do
            {
                if (!xmlIn.Read()) throw new ArgumentException("Ошибка чтения"); // Читаем следующий элемент

                // Если это закрывающий тег RosesPlant - читать больше нечего
                if (xmlIn.NodeType == XmlNodeType.EndElement
                    && xmlIn.Name == nameof(RosesPlant)) break;

                // Пропускаем закрывающие теги
                if (xmlIn.NodeType == XmlNodeType.EndElement) continue;

                if (xmlIn.Name == nameof(Rose))
                {
                    yield return Rose.ReadFromFile(xmlIn); // Создаем и заполняем класс розы
                }

            } while (!xmlIn.EOF); // Пока не конец файла

        }
    }
}

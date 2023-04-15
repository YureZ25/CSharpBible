using XmlFiles;

RosesPlant.SaveProject(Rose.GetDefaultList()); // Сохранение дефолтного списка роз в созданный файл

var roses = RosesPlant.OpenProject(); // Чтение списка роз из существующего файла

foreach (var rose in roses)
{
    Console.WriteLine(rose);
}
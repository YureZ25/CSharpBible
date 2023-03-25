using XmlFiles;

RosesPlant.SaveProject(Rose.GetDefaultList());

var roses = RosesPlant.OpenProject();

foreach (var rose in roses)
{
    Console.WriteLine(rose);
}
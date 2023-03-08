using System.Xml.Linq;

var root = XElement.Load("./../../../person.xml");

Console.WriteLine("Спосок людей старше 16");
foreach (var item in root
    .Elements("person")
    .Where(e => Convert.ToInt32(e.Attribute("age")?.Value) < 16))
{
    Console.WriteLine(item.Attribute("FirstName")?.Value);
}

Console.WriteLine("\nСпосок людей живущих в Ростове");
foreach (var item in root
    .Elements("person")
    .Where(e => e.Elements("address").Elements("city").First().Value == "Ростов"))
{
    Console.WriteLine(item.Attribute("FirstName")?.Value);
}
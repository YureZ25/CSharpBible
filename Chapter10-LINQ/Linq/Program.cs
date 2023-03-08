using Linq;

int ageContition;
var people = Person.GetPeople();

// SQL и лямбда синтаксис
ageContition = 26;
var results = from p in people
              where p.Age > ageContition
              select new { p.FirstName, p.Age };

Console.WriteLine($"Люди старше {ageContition}");
foreach (var p in results)
{
    Console.WriteLine($"Имя: {p.FirstName}; Возраст - {p.Age};");
}

Console.WriteLine($"\nЛюди младше {ageContition}");
foreach (var p in people.Where(p => p.Age < ageContition))
{
    Console.WriteLine($"Имя: {p.FirstName}; Возраст - {p.Age};");
}

// Магия IEnumerable
var filtered = people.Where(p => p.Age < ageContition);

Console.WriteLine($"\n\nЛюди младше {ageContition}");
foreach (var p in filtered)
{
    Console.WriteLine(p);
}

var leo = new Person("Лёня", "Никитин", 19);
Console.WriteLine($"\nДобавим человека: {leo}");
people.Add(leo);

Console.WriteLine($"\nЛюди младше {ageContition}");
foreach (var p in filtered)
{
    Console.WriteLine(p);
}

// Доступ к данным
var filterFirst = "Юра";
if (people.Any(p => p.FirstName == filterFirst))
{
    var yura = people.First(p => p.FirstName == filterFirst);
    Console.WriteLine($"\nПервый по условию: {yura}");
}

Console.WriteLine("\nПервые 2 после 3х");
foreach (var p in people.Skip(2).Take(3))
{
    Console.WriteLine(p);
}
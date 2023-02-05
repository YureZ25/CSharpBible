using BaseObject;

Console.WriteLine("Переопредение ToString()");
Person person = new Person("Юрий", "Никитин");
Console.WriteLine(person.ToString());

object obj = person;
Console.WriteLine(obj.ToString());


Person p1 = new("Юрий", "Никитин");
Person p2 = new("Юрий", "Никитин");
Person p3 = p1;

Console.WriteLine("\nПереопределение Equals()");
Console.WriteLine(p1.Equals(p2));
Console.WriteLine(p1.Equals(p3));

Console.WriteLine("\nСравнение по значению и по ссылке");
Console.WriteLine(ComparePersons(p1, p2));
Console.WriteLine(ComparePersons(p1, p3));

Console.WriteLine("\nПереопредение GetHashCode()");
Console.WriteLine(p1.GetHashCode());
Console.WriteLine(p2.GetHashCode());
Console.WriteLine(p3.GetHashCode());


string ComparePersons(Person person1, Person person2)
{
    bool equalData = person1.Equals(person2);
    // Т.к. метод Equals переопределен через new - можем получить к нему доступ через родителя
    bool equalRefs = ((object)person1).Equals(person2);

    if (equalRefs) return "Ссылки объектов одинаковые";
    if (equalData) return "Данные объектов одинаковые";
    return "Объекты разные";
}
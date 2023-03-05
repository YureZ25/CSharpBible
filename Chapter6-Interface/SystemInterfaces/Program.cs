using SystemInterfaces;

var person = new Person("Yura", "Nik", new Company("SPL"));
var samePerson = person;

Console.WriteLine($"Объекты с одинаковой ссылкой = {person.Equals(samePerson)}");

var newPerson = person.Clone() as Person;

Console.WriteLine($"Объекты с одинаковой ссылкой = {person.Equals(newPerson)}");
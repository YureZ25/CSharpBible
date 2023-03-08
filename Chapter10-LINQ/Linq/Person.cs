namespace Linq
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new("Юра", "Никитин", 25),
                new("Таня", "Прокопенко", 20),
                new("Марк", "Васильев", 27),
                new("Никита", "Дубенко", 26),
                new("Андрей", "Чернышев", 28),
            };
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Age}";
        }
    }
}

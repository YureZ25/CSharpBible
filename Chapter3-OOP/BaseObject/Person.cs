namespace BaseObject
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public new bool Equals(object? obj)
        {
            return obj is Person person
                && FirstName == person.FirstName
                && LastName == person.LastName;
        }

        public override int GetHashCode()
        {
            Console.WriteLine($"Базовый хешкод: {base.GetHashCode()}");

            var h = new HashCode();
            h.Add(FirstName);
            h.Add(LastName);
            return h.ToHashCode();
        }
    }
}

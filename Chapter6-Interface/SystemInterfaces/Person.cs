namespace SystemInterfaces
{
    internal class Person : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }

        public Person(string firstName, string lastName, Company company)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
        }

        public object Clone()
        {
            // Если нет вложенных объектов
            // return MemberwiseClone()

            return new Person(FirstName, LastName, new Company(Company.Name));
        }
    }
}

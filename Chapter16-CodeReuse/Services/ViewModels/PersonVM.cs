using Data.Entities;

namespace Services.ViewModels
{
    public class PersonVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public PersonVM()
        {
            
        }

        public PersonVM(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Age = person.Age;
        }
    }
}

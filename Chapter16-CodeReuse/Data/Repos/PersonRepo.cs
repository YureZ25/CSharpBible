using Data.Entities;
using Data.Repos.Contracts;

namespace Data.Repos
{
    internal class PersonRepo : IPersonRepo
    {
        private List<Person> _persons;

        public PersonRepo()
        {
            _persons = SomeDB.Persons;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await Task.FromResult(_persons);
        }

        public async Task<Person> GetById(int id)
        {
            return await Task.FromResult(_persons.FirstOrDefault(x => x.Id == id));
        }

        public Task<Person> Insert(Person person)
        {
            _persons.Add(person);

            return Task.FromResult(person);
        }

        public Task<Person> Update(Person person)
        {
            var p = _persons.First(e => e.Id == person.Id);

            p.Name = person.Name;
            p.Age = person.Age;

            return Task.FromResult(p);
        }

        public Task<Person> DeleteById(int id)
        {
            var p = _persons.First(e => e.Id == id);

            _persons.Remove(p);

            return Task.FromResult(p);
        }
    }
}

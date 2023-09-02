using Data.Entities;
using Data.Repos.Contracts;
using Services.Services.Contracts;
using Services.ViewModels;

namespace Services.Services
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonRepo _personRepo;

        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public async Task<IEnumerable<PersonVM>> GetAll()
        {
            var persons = await _personRepo.GetAll();

            return persons.Select(e => new PersonVM(e));
        }

        public async Task<PersonVM> GetById(int id)
        {
            var person = await _personRepo.GetById(id);

            return new PersonVM(person);
        }

        public async Task<PersonVM> Insert(PersonVM personVM)
        {
            var person = new Person
            {
                Id = personVM.Id,
                Name = personVM.Name,
                Age = personVM.Age,
            };

            person = await _personRepo.Insert(person);

            return new PersonVM(person);
        }

        public async Task<PersonVM> Update(PersonVM personVM)
        {
            var person = new Person
            {
                Id = personVM.Id,
                Name = personVM.Name,
                Age = personVM.Age,
            };

            person = await _personRepo.Update(person);

            return new PersonVM(person);
        }

        public async Task<PersonVM> DeleteById(int id)
        {
            var person = await _personRepo.DeleteById(id);

            return new PersonVM(person);
        }
    }
}

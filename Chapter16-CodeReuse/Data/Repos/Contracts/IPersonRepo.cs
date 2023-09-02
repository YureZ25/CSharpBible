using Data.Entities;

namespace Data.Repos.Contracts
{
    public interface IPersonRepo
    {
        Task<IEnumerable<Person>> GetAll();

        Task<Person> GetById(int id);

        Task<Person> Insert(Person person);

        Task<Person> Update(Person person);

        Task<Person> DeleteById(int id);
    }
}

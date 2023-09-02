using Services.ViewModels;

namespace Services.Services.Contracts
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonVM>> GetAll();

        Task<PersonVM> GetById(int id);

        Task<PersonVM> Insert(PersonVM personVM);

        Task<PersonVM> Update(PersonVM personVM);

        Task<PersonVM> DeleteById(int id);
    }
}

using EndangerPlantApp.Data.Entities;

namespace EndangerPlantApp.Repositories.Abstractions
{
    public interface IPlantRepository
    {
        Task CreateAsync(Plant plant);
        Task<Plant> UpdateAsync(Plant plant);
        Task DeleteByIdAsync(int id);
        Task<ICollection<Plant>> GetAllAsync();
        ICollection<Plant> GetByFilter(Func<Plant, bool> predicate);
        Task<Plant?> GetByIdAsync(int id);
    }
}

using EndangerPlantApp.DTOs;

namespace EndangerPlantApp.Services.Abstractions
{
    public interface IPlantServices 
    {
        Task<PlantDTO> GetByIdAsync(int id);
        Task CreateAsync(PlantDTO plantDTO);
        Task UpdateAsync(PlantDTO plantDTO);
        Task DeleteAsync(int id);   
        Task<ICollection<PlantDTO>> GetAllAsync();
    }
}

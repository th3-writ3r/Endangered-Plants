using AutoMapper;
using EndangerPlantApp.Data.Entities;
using EndangerPlantApp.DTOs;
using EndangerPlantApp.Repositories.Abstractions;
using EndangerPlantApp.Services.Abstractions;

namespace EndangerPlantApp.Services
{
    public class PlantServices : IPlantServices
    {
        private readonly IMapper _mapper;
        private readonly IPlantRepository _plantRepository;
        public PlantServices(IMapper mapper, IPlantRepository plantRepository)
        {
            _mapper = mapper;
            _plantRepository = plantRepository;
        }

        public async Task CreateAsync(PlantDTO plantDTO)
        {
            var plant = _mapper.Map<Plant>(plantDTO);
            await _plantRepository.CreateAsync(plant);
        }

        public async Task DeleteAsync(int id)
        {
            await _plantRepository.DeleteByIdAsync(id);
        }

        public async Task<ICollection<PlantDTO>> GetAllAsync()
        {
            var plants = await _plantRepository.GetAllAsync();
            return _mapper.Map<ICollection<PlantDTO>>(plants);
        }

        public async Task<PlantDTO> GetByIdAsync(int id)
        {
            var plant = _plantRepository.GetByIdAsync(id);
            return _mapper.Map<PlantDTO>(plant);
        }

        public async Task UpdateAsync(PlantDTO plantDTO)
        {
            var plant = _mapper.Map<Plant>(plantDTO);
            await _plantRepository.UpdateAsync(plant);
        }
    }
}

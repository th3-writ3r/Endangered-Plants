using AutoMapper;
using EndangerPlantApp.Data.Entities;
using EndangerPlantApp.DTOs;

namespace EndangerPlantApp.Profiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile()
        {
            CreateMap<Plant, PlantDTO>().ReverseMap();
        }
    }
}

using EndangerPlantApp.Data;
using EndangerPlantApp.Data.Entities;
using EndangerPlantApp.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.Reflection.Metadata.Ecma335;

namespace EndangerPlantApp.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Plant> _dbSet;
        public PlantRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Plant;
        }
        public async Task CreateAsync(Plant plant)
        {
            _context.Plant.Add(plant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Plant plant = await GetByIdAsync(id);
            if (plant != null) 
            {
                _context.Remove(plant);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"No plant with id {id} exists.");
            }
        }

        public async Task<ICollection<Plant>> GetAllAsync()
        {
            return await _context.Plant.ToListAsync();
        }

        // TO DO: vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        //public async ICollection<Plant> GetByFilter(Func<Plant, bool> predicate)
        //{
        //   return await _context.Plant
        //        .Where(predicate)
        //       .ToListAsync();
        //}
        // ---------------------------------------------------------------


        public ICollection<Plant> GetByFilter(Func<Plant, bool> predicate)
        {
            return _context.Plant
                .Where(predicate)
                .ToList();
            //why r u being a little bitch
        }

        public async Task<Plant?> GetByIdAsync(int id)
        {
            return await _context.Plant.FindAsync(id);
        }

        public async Task<Plant> UpdateAsync(Plant plant)
        {
            _context.Plant.Update(plant);
            await _context.SaveChangesAsync();
            return plant;
        }
    }
}

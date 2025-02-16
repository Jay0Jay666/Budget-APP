using Microsoft.EntityFrameworkCore;
using Budget_APP.Context;
using Budget_APP.Models.DataBase;
using Budget_APP.Repositories.Interfaces;

namespace Budget_APP.Repositories
{
    public class GenderRepositories : IGenderRepositories
    {
        private readonly ApplicationDbContext _context;
        public GenderRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetAllGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender> UpdateGenderAsync(Gender gender)
        {
            _context.Genders.Update(gender);
            await _context.SaveChangesAsync();
            return gender;
        }
        public async Task<Gender> AddGenderAsync(Gender gender)
        {
            await _context.Genders.AddAsync(gender);
            await _context.SaveChangesAsync();
            return gender;
        }
        public async Task<Gender> GetGenderByIdAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            return gender ?? throw new KeyNotFoundException($"gender with id {id} not found.");
        }

        public async Task<Gender> DeleteGenderAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender != null)
            {
                _context.Genders.Remove(gender);
                await _context.SaveChangesAsync();
            }
            if (gender == null)
            {
                throw new KeyNotFoundException($"Gender with id {id} not found.");
            }
            return gender;
        }
}
}
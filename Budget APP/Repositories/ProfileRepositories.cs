using Budget_APP.Context;
using Budget_APP.Models.DataBase;
using Budget_APP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Budget_APP.Repositories
{
    public class ProfileRepositories : IProfileRepositories
    {
        private readonly ApplicationDbContext _context;
        public ProfileRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
        {
            return await _context.Profiles.ToListAsync();
        }
        public async Task<Profile> GetProfileByIdAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            return profile ?? throw new KeyNotFoundException($"Profile with id {id} not found.");
        }

        public async Task<Profile> AddProfileAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return profile;
        }
        public async Task<Profile> UpdateProfileAsync(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
            return profile;
        }
        public async Task<Profile> DeleteProfileAsync(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
            if (profile == null)
            {
                throw new KeyNotFoundException($"Profile with id {id} not found.");
            }
            return profile;
        }

    }
}

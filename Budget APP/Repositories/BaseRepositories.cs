using Microsoft.EntityFrameworkCore;
using Budget_APP.Data;
using Budget_APP.Models.DataBase;



namespace Budget_APP.Repositories
{
    public class BaseRepositories : IBaseRepositories
    {
        private readonly ApplicationDbContext _context;
        public BaseRepositories(ApplicationDbContext context)
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
            return profile == null ? throw new KeyNotFoundException($"Profile with id {id} not found.") : profile;
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

        public Task<IEnumerable<Profile>> GetallProfilesAsnc()
        {
            throw new NotImplementedException();
        }
    }
}

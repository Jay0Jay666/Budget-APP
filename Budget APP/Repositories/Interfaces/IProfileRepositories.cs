using Budget_APP.Models.DataBase;

namespace Budget_APP.Repositories.Interfaces
{
    public interface IProfileRepositories
    {
        Task<IEnumerable<Profile>> GetAllProfilesAsync();
        Task<Profile> GetProfileByIdAsync(int id);
        Task<Profile> AddProfileAsync(Profile profile);
        Task<Profile> UpdateProfileAsync(Profile profile);
        Task<Profile> DeleteProfileAsync(int id);
    }
}

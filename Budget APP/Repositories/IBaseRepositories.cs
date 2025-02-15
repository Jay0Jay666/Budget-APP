using Budget_APP.Models.DataBase;



namespace Budget_APP.Repositories
{
    public interface IBaseRepositories
    {
        Task<IEnumerable<Profile>> GetallProfilesAsnc();
        Task<Profile> GetProfileByIdAsync(int id);
        Task<Profile> AddProfileAsync(Profile profile);
        Task<Profile> UpdateProfileAsync(Profile profile);
        Task<Profile> DeleteProfileAsync(int id);
    }
}


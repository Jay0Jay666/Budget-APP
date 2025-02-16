using Budget_APP.Models.DataBase;

namespace Budget_APP.Repositories.Interfaces
{
    public interface IGenderRepositories
    {
        Task<IEnumerable<Gender>> GetAllGendersAsync();
        Task<Gender> GetGenderByIdAsync(int id);
        Task<Gender> UpdateGenderAsync(Gender gender);
        Task<Gender> AddGenderAsync(Gender gender);
        Task<Gender> DeleteGenderAsync(int id);
    }
}

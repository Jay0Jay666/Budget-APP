using Microsoft.EntityFrameworkCore;
using Budget_APP.Models.DataBase;

namespace Budget_APP.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public required DbSet<Profile> Profiles { get; set; }
        public required DbSet<Gender> Genders { get; set; }

    }
}

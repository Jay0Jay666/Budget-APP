using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_APP.Models.DataBase
{
    [Table("profile")]
    public class Profile
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Username { get; set; }
    }
}

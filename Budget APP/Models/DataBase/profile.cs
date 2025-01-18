using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_APP.Models.DataBase
{
    [Table("profile")]
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }= string.Empty;
        public Profile(int id, string name, string surname, string email, string password, string username)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Username = username;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_APP.Models.DataBase
{
    [Table("Gender")]
    public class Gender
    {
        public int GenderId { get; set; }
        public required string Name { get; set; }

        public required ICollection<Gender> Profiles { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("Username"), NotNull]
        public string? Username { get; set; }
        [Column("Password"), NotNull]
        public string? Password { get; set; }
        public bool IsLoggedInUser { get; set; }
        [Ignore]
        public virtual ICollection<Player>? MyPlayers { get; set; }
        [Ignore]
        public virtual ICollection<Question>? MadeQuestions { get; set; }
    }
}

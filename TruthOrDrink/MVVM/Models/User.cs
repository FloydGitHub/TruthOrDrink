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


        public static User GetUser(string username, string password)
        {
            User user = App.UserRepo.GetUser(username, password);
            return user;
        }

        public static User? GetLoggedInUser()
        {
            User? user = App.UserRepo.GetLoggedInUser();
            return user;
        }

        public void AddOrUpdateUser()
        {
            App.UserRepo.AddOrUpdateUser(this);
        }

    }
}

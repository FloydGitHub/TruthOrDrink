using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public required string Username { get; set; }
        //public string Password { get; set; }
        public virtual ICollection<Player>? MyPlayers { get; set; }
        public virtual ICollection<Question>? MadeQuestions { get; set; }
    }
}

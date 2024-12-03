using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int TwistCard { get; set; }
        public int Answers { get; set; }
        public int Drinks { get; set; }
        public bool IsHost { get; set; }
        [Required]
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }

    }
}

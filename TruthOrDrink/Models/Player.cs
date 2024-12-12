using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    [Table("Players")]
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public required string Name { get; set; }
        public int TwistCard { get; set; }
        public int Answers { get; set; }
        public int Drinks { get; set; }
        public bool IsHost { get; set; }
        // forreign key
        public int? GameId { get; set; }
        [Ignore]
        public virtual Game? Game { get; set; }

    }
}

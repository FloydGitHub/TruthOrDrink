using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    [Table("GameCategories")]
    class GameCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //foreign key
        public int GameId { get; set; }
        //foreign key
        public int CategoryId { get; set; }
    }
}

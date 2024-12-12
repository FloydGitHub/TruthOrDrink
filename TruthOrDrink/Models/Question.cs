using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    [Table("Questions")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string? Text {  get; set; }
        [NotNull]
        public int Level { get; set; }
        public bool CustomQuestion { get; set; }
        public bool PhotoQuestion { get; set; }
        //foreign key
        [Column("CreatorId")]
        public int? CreatorId { get; set; }
        [Ignore]
        public virtual User? Creator { get; set; }
        //foreign key
        public int CategoryId { get; set; }
        [Ignore]
        public virtual Category? Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    internal class Question
    {
        public int Id { get; set; }
        [Required]
        public required string Text {  get; set; }
        [Required]
        public int Level { get; set; }
        public bool CustomQuestion { get; set; }
        public bool PhotoQuestion { get; set; }
        public virtual User? Creator { get; set; }
        public virtual Category? Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    internal class Game
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartingMoment { get; set; }
        public bool Finnished { get; set; }
        public bool CustomQuestionsAllowed { get; set; }
        public bool StandardQuestionsAllowed { get; set; }
        public bool LevelOneAllowed { get; set; }
        public bool LevelTwoAllowed { get; set; }
        public bool LevelThreeAllowed { get; set; }
        public bool LevelFourAllowed { get; set; }
        public bool LevelFiveAllowed { get; set; }

        public virtual ICollection<Player>? Players { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<Question>? QuestionsAsked { get; set; }
    }
}

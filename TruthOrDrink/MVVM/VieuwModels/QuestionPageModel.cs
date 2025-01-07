using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Models;

namespace TruthOrDrink.MVVM.VieuwModels
{
    public class QuestionPageModel
    {
        public Game? CurrentGame { get; set; }
        public Question? QuestionToAsk { get; set; }
        public Player? PlayerToAsk { get; set; }
    }
}

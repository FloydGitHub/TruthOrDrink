using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    internal class Player
    {
        public int Id { get; set; }
        public int TwistCard { get; set; }
        public int Answers { get; set; }
        public int Drinks { get; set; }
    }
}

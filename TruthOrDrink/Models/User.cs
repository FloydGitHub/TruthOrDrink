using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    internal class User
    {
        public int Id { get; set; }
        [Required]
        public required string Username { get; set; }
        //public string Password { get; set; }
        
    }
}

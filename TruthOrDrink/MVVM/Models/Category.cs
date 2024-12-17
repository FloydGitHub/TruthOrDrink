using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Models
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique, NotNull]
        public required string Name { get; set; }
        public required string Description { get; set; }

        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Standaard", Description = "Standaard vragen" },
                new Category { Id = 2, Name = "Spicy", Description = "Vragen die worden aangeraden vanaf 18+" },
                new Category { Id = 3, Name = "Special", Description = "Voornamelijk opdrachten" },

            };
        }
    }
}

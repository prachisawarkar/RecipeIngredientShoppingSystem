using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime ManufacturerDate { get; set; }
        public Decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Description {get; set; }
    }
}

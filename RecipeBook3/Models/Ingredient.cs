using System;
namespace RecipeBook3.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public string Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        /* originally this was gonna be divided, but see recipes saying cored,
         * peeled, crushed, frozen, toasted, etc.
         */
        public string SpecialInstructions { get; set; }

        public Ingredient()
        {
        }
    }
}

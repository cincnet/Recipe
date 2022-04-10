using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace RecipeBook3.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        [DisplayName("Dish Name")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        [DisplayName("Ingredients")]
        public List<Ingredient> IngredientList { get; set; }
        [DisplayName("Steps")]
        public List<Step> StepList { get; set; }
        //public IFormFile Picture { get; set; }

        public Recipe()
        {
        }
    }
}

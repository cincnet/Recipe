using System;
using System.Linq;

namespace RecipeBook3.Models
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
            if(context.Ingredients.Any())
            {
                return; //seeded
            }

            var recipes = new Recipe[]
{
                new Recipe{Title="Roasted Curry Cauliflower", Description="Indian Side dish", Author="Joanna Sayago Golub"},
                new Recipe{Title="Mussels with White Wine and Shallots", Description="Smells like the south of France", Author="The Rodale Test Kitchen"}
};
            foreach (Recipe r in recipes)
            {
                context.Recipes.Add(r);
            }
            context.SaveChanges();

            var Ingredients = new Ingredient[]
            {
                new Ingredient{RecipeID = 1, Amount="1", Unit="Head", Name="Cauliflower", SpecialInstructions=""},
                new Ingredient{RecipeID = 1, Amount="1", Unit="Tbsp", Name="Extra-virgin olive oil", SpecialInstructions=""},
                new Ingredient{RecipeID = 1, Amount="1", Unit="Tsp", Name="Curry Powder", SpecialInstructions=""},
                new Ingredient{RecipeID = 1, Amount="1/2", Unit="Tsp", Name="Salt", SpecialInstructions=""},
                new Ingredient{RecipeID = 1, Amount="1/4", Unit="Tsp", Name="Freshly Ground Black Pepper", SpecialInstructions=""}
            };

            var Ingredients2 = new Ingredient[]
            {
                new Ingredient{RecipeID = 2, Amount="4", Unit="Pounds", Name="Mussels", SpecialInstructions=""},
                new Ingredient{RecipeID = 2, Amount="2", Unit="Tbsp", Name="extra-virgin olive oil", SpecialInstructions=""},
                new Ingredient{RecipeID = 2, Amount="4", Unit="whole", Name="Shallots", SpecialInstructions="Minced"},
                new Ingredient{RecipeID = 2, Amount="3", Unit="Cloves", Name="Garlic", SpecialInstructions="Minced"},
                new Ingredient{RecipeID = 2, Amount="1", Unit="Cup", Name="Dry White Wine", SpecialInstructions=""},
                new Ingredient{RecipeID = 2, Amount="1/4", Unit="Cup", Name="Fresh flat-leaf parsley", SpecialInstructions="Minced"}
            };

            foreach (Ingredient i in Ingredients)
            {
                context.Ingredients.Add(i);
                context.SaveChanges();
            }

            foreach (Ingredient i in Ingredients2)
            {
                context.Ingredients.Add(i);
                context.SaveChanges();
            }

            var Steps = new Step[]
            {
                new Step{RecipeID = 1, StepNumber = 1, Instruction="Preheat the oven to 450*F"},
                new Step{RecipeID = 1, StepNumber = 2, Instruction="Spread the florets on a baking sheet.  Drizzle with the oil.  Sprinkle with the curry powder, salt, and pepper.  Toss well to coat."},
                new Step{RecipeID = 1, StepNumber = 3, Instruction="Roast for 15-20 minutes, until the cauliflower is tender and browned."}
            };

            foreach(Step s in Steps) {
                context.Steps.Add(s);
                context.SaveChanges();
            }

            var Steps2 = new Step[]
            {
                new Step{RecipeID = 2, StepNumber = 1, Instruction="Put the mussels in a large colander set in the sink.  Rinse with cool water" },
                new Step{RecipeID = 2, StepNumber = 2, Instruction="In a 6-quart pot, heat the oil over low heat.  Add shallots and garlic, and cook, stirring for 5 minutes"},
                new Step{RecipeID = 2, StepNumber = 3, Instruction="Add the win, increase to high, and bring to a boil.  Add mussels, cover, and cook for 5-7 minutes"},
                new Step{RecipeID = 2, StepNumber = 4, Instruction="Spoon mussels into 4 serving bowls, stir the parsley into the broth in the pot and spoon over the mussels"}
            };
            foreach(Step s in Steps2)
            {
                context.Steps.Add(s);
                context.SaveChanges();
            }

        }
        public DbInitializer()
        {
        }
    }
}

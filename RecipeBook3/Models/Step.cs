using System;
namespace RecipeBook3.Models
{
    public class Step
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public int StepNumber { get; set; }
        public string Instruction { get; set; }

        public Step()
        {
        }
    }
}

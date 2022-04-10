using System;
namespace RecipeBook3.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        
    }
}

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook3.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook3.Controllers
{
    public class RecipeController : Controller
    {
        private readonly DatabaseContext _context;


        public RecipeController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
            //return View(recipeList);
        }

        [HttpPost]
        public  IActionResult Index(string SearchTerm)
        {
            var y = _context.Recipes.Include(i => i.IngredientList).Include(i => i.StepList).AsEnumerable();
            var r =  _context.Recipes.Include(i => i.IngredientList).Include(i => i.StepList).AsEnumerable().Where(i => i.Title.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase));
            //var results = _context.Recipes.Where(i => i.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
            var s = r.ToList();
            return View(r.ToList());
        }

        //[HttpPost]
        //public IActionResult Index(IFormFile postedFile)
        //{
        //    byte[] bytes;

        //    using(BinaryReader br = new BinaryReader(postedFile.OpenReadStream()))
        //    {
        //        bytes = br.ReadBytes((int)postedFile.Length);
        //    }
        //    long size = postedFile.Length;

        //    var filePath = Path.GetTempFileName();

        //    if(size > 0)
        //    {
        //        using(var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await 
        //        }
        //    }
        //}

        [ActionName("Find")]
        public ActionResult GetById(int id)
        {
            //get from database
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Recipe recipe)
        {
            _context.Update(recipe);
            //_context.Remove(recipe);
            await _context.SaveChangesAsync();
            //edit in database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async  Task<ActionResult> Edit(int id)
        {
            var recipe = await _context.Recipes.Include(i => i.IngredientList).AsNoTracking().FirstOrDefaultAsync(m => m.RecipeID == id);
            recipe.StepList = _context.Steps.Where(r => r.RecipeID == id).ToList();
            //recipe.StepList.Reverse();

            return View(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _context.Recipes.Include(i => i.IngredientList).AsNoTracking().FirstOrDefaultAsync(m => m.RecipeID == id);
            recipe.StepList = _context.Steps.Where(r => r.RecipeID == id).ToList();
            //recipe.StepList.Reverse();

            return View(recipe);
        }

        [HttpGet]
        public IActionResult EditRecipe(int id)
        {
            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var r = await _context.Recipes.Include(i => i.IngredientList).Include(i => i.StepList).ToListAsync();

            var recipe = await _context.Recipes.Include(i => i.IngredientList).AsNoTracking().FirstOrDefaultAsync(m => m.RecipeID == id);
            recipe.StepList = _context.Steps.Where(r => r.RecipeID == id).ToList();
            _context.Remove(recipe);
            await _context.SaveChangesAsync();
            //delete from database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //_context.Remove(id);
            //await _context.SaveChangesAsync();
            //delete from database
            return  await Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Recipe r)
        {
            _context.Add(r);
            await _context.SaveChangesAsync();
            //write to database
            //recipeList.Add(r);
            return RedirectToAction("Edit", new {id = r.RecipeID });
            //return View(recipeList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Recipe r = new Recipe()
            {
                Title = "",
                //RecipeID = 50,
                IngredientList = new List<Ingredient>(),
                StepList = new List<Step>()
            };
            return View(r);
        }

        [HttpGet]
        public ActionResult Add2()
        {
            Recipe r = new Recipe()
            {
                Title = "",
                //RecipeID = 50,
                IngredientList = new List<Ingredient>(),
                StepList = new List<Step>()
            };
            return View(r);
        }

        [HttpGet]
        public ViewResult BlankStepRow(int RecipeId)
        {
            return View("BlankStepRow", new Step() { RecipeID = RecipeId });
        }

        [HttpPost]
        public async Task<IActionResult> BlankStepRow(Step s)
        {
            _context.Steps.Add(s);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = s.RecipeID });
        }

        [HttpGet]
        public ViewResult BlankIngredientRowAdd(int RecipeId)
        {
            return View("BlankIngredientRow", new Ingredient() { RecipeID = RecipeId });
        }

        [HttpPost]
        public async Task<IActionResult> BlankIngredientRowAdd(Ingredient i)
        {
            _context.Ingredients.Add(i);
            await _context.SaveChangesAsync();
            return await Details(i.RecipeID);
        }

        [HttpGet]
        public ViewResult BlankIngredientRow(int RecipeId)
        {
            return View("BlankIngredientRow", new Ingredient() { RecipeID = RecipeId });
        }

        [HttpPost]
        public  async Task<IActionResult> BlankIngredientRow(Ingredient i)
        {
            _context.Ingredients.Add(i);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = i.RecipeID });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStep(int stepID, int RecipeID)
        {
            var step = await _context.Steps.AsNoTracking().FirstOrDefaultAsync(m => m.ID == stepID);
            _context.Steps.Remove(step);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = RecipeID });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteIngredient(int IngredientID, int RecipeID)
        {
            var ingredient = await _context.Ingredients.AsNoTracking().FirstOrDefaultAsync(m => m.ID == IngredientID);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = RecipeID });
        }
    }


}




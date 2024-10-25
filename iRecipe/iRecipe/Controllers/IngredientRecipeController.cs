using iRecipeAPI.Domain;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class IngredientRecipeController : ControllerBase
    {
        private IIngredientRecipeService _ingredientRecipeService;
        private IIngredientService _ingredientService;

        public IngredientRecipeController(IIngredientRecipeService ingredientRecipeService, IIngredientService ingredientService)
        {
            _ingredientRecipeService = ingredientRecipeService;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public List<IngredientRecipe> GetAllIngredientRecipes()
        {
            return _ingredientRecipeService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ingredientrecipe = _ingredientRecipeService.GetById(id);
            if (ingredientrecipe == null)
            {
                return NotFound(); 
            }
            return Ok(ingredientrecipe); 
        }

        [HttpGet("Recipe/{RecipeId}")]
        public IActionResult GetByRecipeId(int RecipeId)
        {
            var ingredientrecipe = _ingredientRecipeService.GetAllByRecipeId(RecipeId);
            if (ingredientrecipe == null)
            {
                return NotFound(); 
            }
            return Ok(ingredientrecipe);
        }

        [HttpPost]
        public IActionResult SaveIngredientRecipe([FromForm] IngredientRecipe ingredientRecipe)
        {
            
           
            var ingredient = _ingredientService.GetOrCreateIngredient(ingredientRecipe.Ingredient.Name);

            
            ingredientRecipe.IngredientId = ingredient.Id;


            _ingredientRecipeService.SaveIngredientRecipe(ingredientRecipe);
  

            return Ok(new { message = "Ingrediente associado à Receita com sucesso", data = ingredientRecipe });
        }


        [HttpDelete("{id}")]
        public void DeleteIngredientRecipe(int id)
        {
            _ingredientRecipeService.RemoveIngredientRecipe(id);
        }

    }
}

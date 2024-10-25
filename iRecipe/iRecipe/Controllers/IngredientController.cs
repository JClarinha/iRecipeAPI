using iRecipeAPI.Domain;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ingredient = _ingredientService.GetById(id);
            if (ingredient == null)
            {
                return NotFound(); 
            }
            return Ok(ingredient); 
        }

        [HttpGet ("name")]
        public Ingredient GetByName(string name)
        {
            return _ingredientService.GetByName(name);
        }

        [HttpPost]
        public Ingredient SaveIngredient(Ingredient ingredient)
        {
            return _ingredientService.SaveIngredient(ingredient);
        }

        [HttpDelete("{id}")]
        public void DeleteIngredient(int id)
        {
            _ingredientService.RemoveIngredient(id);
        }

    }
}

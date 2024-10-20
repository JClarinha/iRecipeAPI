using iRecipeAPI.Data.Context;
using iRecipeAPI.Domain;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeService _recipeService;
        private readonly iRecipeAPIDBContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public RecipeController(IRecipeService recipeService, iRecipeAPIDBContext dbContext, IWebHostEnvironment environment)
        {
            _recipeService = recipeService;
            _dbContext = dbContext;
            _environment = environment;
        }

        [HttpGet]
        public List<Recipe> GetAllRecipes()
        {
            return _recipeService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var recipe = _recipeService.GetById(id);
            if (recipe == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(recipe); // Retorna 200 com os dados da categoria
        }


        /*

        [HttpPost] // EUREKA
        public IActionResult SaveRecipe([FromForm] Recipe recipe)
        {
            // Verificar se a imagem foi fornecida
            if (recipe.Image != null)
            {
                // Definir o caminho para armazenar a imagem
                var fileName = Path.GetFileNameWithoutExtension(recipe.Image.FileName);
                var extension = Path.GetExtension(recipe.Image.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "images", $"{fileName}_{DateTime.Now.Ticks}{extension}");

                // Criar a pasta "images" se não existir
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Guardar a imagem no servidor de forma síncrona
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    recipe.Image.CopyTo(stream);
                }

                // Guardar o caminho da imagem na entidade
                recipe.ImagePath = filePath;
            }

            // Adicionar a receita à base de dados de forma síncrona
            _dbContext.Recepies.Add(recipe);
            _dbContext.SaveChanges();



            // Processar e associar os ingredientes
            if (recipe.IngredientRecipes != null && recipe.IngredientRecipes.Any())
            {
                foreach (var ingredient in recipe.IngredientRecipes)
                {
                    // Criar o objeto IngredientRecipe com as propriedades necessárias
                    var ingredientRecipe = new IngredientRecipe
                    {
                        RecipeId = recipe.Id,  // ID da receita que acabou de ser criada
                        IngredientId = ingredient.IngredientId,
                        Quantity = ingredient.Quantity,
                        UnitId = ingredient.UnitId
                    };

                    _dbContext.IngredientRecepies.Add(ingredientRecipe);
                }

                _dbContext.SaveChanges();
            }


            // Retornar uma resposta bem-sucedida
            return Ok(new { message = "Receita adicionada com sucesso", data = recipe });
        }
        */

        /*
        [HttpPost]
        public IActionResult SaveRecipe([FromForm] Recipe recipe)
        {
            // Verificar se a imagem foi fornecida
            if (recipe.Image != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(recipe.Image.FileName);
                var extension = Path.GetExtension(recipe.Image.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "images", $"{fileName}_{DateTime.Now.Ticks}{extension}");

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    recipe.Image.CopyTo(stream);
                }

                recipe.ImagePath = filePath;
            }

            // Chamar o serviço para salvar a receita e seus ingredientes
            var result = _recipeService.SaveRecipe(recipe);

            return Ok(new { message = "Receita adicionada com sucesso", data = recipe });
        }*/

        [HttpPost]
        public Recipe SaveCategory(Recipe recipe)
        {
            if (recipe.Image != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(recipe.Image.FileName);
                var extension = Path.GetExtension(recipe.Image.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "images", $"{fileName}_{DateTime.Now.Ticks}{extension}");

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    recipe.Image.CopyTo(stream);
                }

                recipe.ImagePath = filePath;
            }

            return _recipeService.SaveRecipe(recipe);
        }


        [HttpDelete]
        public void DeleteRecipe(int id)
        {
            _recipeService.RemoveRecipe(id);
        }

    }
}

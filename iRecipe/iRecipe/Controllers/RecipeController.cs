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

        

        [HttpGet("User/{UserId}")]
        public List<Recipe> GetByUserId(int UserId)
        {
            try
            {
                var recipes = _recipeService.GetByUserId(UserId); // Presumindo que isso retorne List<Recipe>
                if (recipes == null || !recipes.Any())
                {
                    return new List<Recipe>(); // Retorna uma lista vazia se não houver receitas
                }
                return recipes; // Retorna as receitas
            }
            catch (Exception ex)
            {
                // Aqui você pode logar o erro, mas como está retornando uma lista, não pode retornar StatusCode
                // Por isso, é melhor garantir que o método de serviço sempre retorne uma lista, mesmo em erro
                return new List<Recipe>(); // Retorna uma lista vazia em caso de erro
            }
        }

        [HttpGet("images/{*filename}")]
        public IActionResult GetImage(string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }
            return PhysicalFile(path, "image/png");
        }

        

        [HttpPost]
        public Recipe SaveRecipe(Recipe recipe)

        {

                if (recipe.Image != null )
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



        [HttpPut]
        public IActionResult UpdateRecipe([FromForm] Recipe recipe)
        {
            try
            {
                var existingRecipe = _recipeService.GetById(recipe.Id);

                if (existingRecipe == null)
                {
                    return NotFound("Receita não encontrada.");
                }

                // Atualiza apenas os campos que foram enviados no FormData
                if (!string.IsNullOrEmpty(recipe.Name) && recipe.Name != existingRecipe.Name)
                {
                    existingRecipe.Name = recipe.Name;
                }

                if (!string.IsNullOrEmpty(recipe.Description) && recipe.Description != existingRecipe.Description)
                {
                    existingRecipe.Description = recipe.Description;
                }

                if (recipe.Pax != existingRecipe.Pax)
                {
                    existingRecipe.Pax = recipe.Pax;
                }

                if (recipe.Duration != existingRecipe.Duration)
                {
                    existingRecipe.Duration = recipe.Duration;
                }

                if (recipe.CategoryId != existingRecipe.CategoryId)
                {
                    existingRecipe.CategoryId = recipe.CategoryId;
                }

                if (recipe.DifficultyId != existingRecipe.DifficultyId)
                {
                    existingRecipe.DifficultyId = recipe.DifficultyId;
                }

                if (!string.IsNullOrEmpty(recipe.Preparation) && recipe.Preparation != existingRecipe.Preparation)
                {
                    existingRecipe.Preparation = recipe.Preparation;
                }

                if (recipe.Approval != null && recipe.Approval != existingRecipe.Approval)
                {
                    existingRecipe.Approval = recipe.Approval;
                }

                // Verifica se uma nova imagem foi enviada
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

                    existingRecipe.ImagePath = filePath;  // Atualiza o caminho da imagem
                }

                // Atualiza a receita no banco de dados
                var updatedRecipe = _recipeService.UpdateRecipe(existingRecipe);

                return Ok(updatedRecipe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar receita: {ex.Message}");
            }
        }






        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            _recipeService.RemoveRecipe(id);
        }

    }
}

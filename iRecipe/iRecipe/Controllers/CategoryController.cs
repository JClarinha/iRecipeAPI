using iRecipeAPI.Domain;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(category); // Retorna 200 com os dados da categoria
        }

        [HttpPost]
        public Category SaveCategory(Category category)
        {
            return _categoryService.SaveCategory(category);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.RemoveCategory(id);
        }

    }
}

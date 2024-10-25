using iRecipeAPI.Domain;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private IDifficultyService _difficultyService;

        public DifficultyController(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        [HttpGet]
        public List<Difficulty> GetAllDifficulties()
        {
            return _difficultyService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var difficulty = _difficultyService.GetById(id);
            if (difficulty == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(difficulty); // Retorna 200 com os dados da categoria
        }

        [HttpPost]
        public Difficulty SaveDifficulty(Difficulty difficulty)
        {
            return _difficultyService.SaveDifficulty(difficulty);
        }

        [HttpDelete("{id}")]
        public void DeleteDifficulty(int id)
        {
            _difficultyService.RemoveDifficulty(id);
        }

    }
}

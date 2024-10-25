using iRecipeAPI.Domain;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private IFavouriteService _favouriteService;
        private IUserService _userService;
        private IRecipeService _recipeService;

        public FavouriteController(IFavouriteService favouriteService, IUserService userService, IRecipeService recipeService)
        {
            _favouriteService = favouriteService;
            _userService = userService;
            _recipeService = recipeService;
        }

        [HttpGet]
        public List<Favourite> GetAllFavourites()
        {
            return _favouriteService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var favourite = _favouriteService.GetById(id);
            if (favourite == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(favourite); // Retorna 200 com os dados da categoria
        }

        [HttpGet("User/{UserId}")]
        public IActionResult GetByUserId(int UserId)
        {
            var favourite = _favouriteService.GetAllByUserId(UserId);

            if (favourite == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(favourite); // Retorna 200 com os dados da categoria
        }


        [HttpPost]
        public IActionResult SaveFavourite([FromForm] Favourite favourite)
        {

            var user = _userService.GetById(favourite.UserId);
            var recipe = _recipeService.GetById(favourite.RecipeId);

            if (user == null && recipe == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }

            favourite.Recipe = recipe;
            favourite.User = user;
            _favouriteService.SaveFavourite(favourite);

            return Ok(new { message = "Favorito associado à Receita com sucesso", data = favourite });
        }






        [HttpDelete("{id}")]
        public void DeleteFavourite(int id)
        {
            _favouriteService.RemoveFavourite(id);
        }

    }
}

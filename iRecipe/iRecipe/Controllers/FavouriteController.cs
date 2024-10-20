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

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
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
        /*
        [HttpPost]
        public Favourite SaveFavourite(Favourite favourite)
        {
            return _favouriteService.SaveFavourite(favourite);
        }
        */

        [HttpPost]
        public IActionResult SaveFavourite([FromForm] Favourite favourite)
        {
            _favouriteService.SaveFavourite(favourite);

            return Ok(new { message = "Comentário adicionado com sucesso", data = favourite });
        }



        [HttpDelete]
        public void DeleteFavourite(int id)
        {
            _favouriteService.RemoveFavourite(id);
        }

    }
}

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


    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        private IUserService _userService;
        private IRecipeService _recipeService;

        public CommentController(ICommentService commentService, IUserService userService, IRecipeService recipeService)
        {
            _commentService = commentService;
            _userService = userService;
            _recipeService = recipeService;
        }

        [HttpGet]
        public List<Comment> GetAllComments()
        {
            return _commentService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comment = _commentService.GetById(id);
            if (comment == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(comment); // Retorna 200 com os dados da categoria
        }

        [HttpGet("User/{UserId}")]
        public IActionResult GetByUserId(int UserId)
        {
            var comment = _commentService.GetAllByUserId(UserId);

            if (comment == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(comment); // Retorna 200 com os dados da categoria
        }

        /*[HttpPost]
        public Comment SaveComment(Comment comment)
        {
            return _commentService.SaveComment(comment);
        }*/


        [HttpPost]
        public IActionResult SaveComment([FromForm] Comment comment)
        {

            var user = _userService.GetById(comment.UserId);
            var recipe = _recipeService.GetById(comment.RecipeId);

            if (user == null && recipe == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }

            comment.Recipe = recipe;
            comment.User = user;
            _commentService.SaveComment(comment);

            return Ok(new { message = "Comentário associado à Receita com sucesso", data = comment });
        }



        [HttpDelete("{id}")]
        public void DeleteComment(int id)
        {
            _commentService.RemoveComment(id);
        }

    }
}

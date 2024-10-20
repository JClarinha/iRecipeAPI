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
        private readonly iRecipeAPIDBContext _dbContext;

        public CommentController(ICommentService commentService, iRecipeAPIDBContext dbContext)
        {
            _commentService = commentService;
            _dbContext = dbContext;
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

        /*[HttpPost]
        public Comment SaveComment(Comment comment)
        {
            return _commentService.SaveComment(comment);
        }*/

        [HttpPost]
        public IActionResult SaveComment([FromForm] Comment comment)
        {

            _commentService.SaveComment(comment);


            return Ok(new { message = "Comentário adicionado com sucesso", data = comment });
        }



        [HttpDelete]
        public void DeleteComment(int id)
        {
            _commentService.RemoveComment(id);
        }

    }
}

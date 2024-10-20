using iRecipeAPI.Domain;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _userService.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(user); // Retorna 200 com os dados da categoria
        }

        [HttpPost]
        public User SaveUser(User user)
        {
            return _userService.SaveUser(user);
        }

        [HttpDelete]
        public void DeleteUser(int id)
        {
            _userService.RemoveUser(id);
        }

    }
}

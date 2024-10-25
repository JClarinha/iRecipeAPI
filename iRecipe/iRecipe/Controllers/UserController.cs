using iRecipeAPI.Domain;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



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


        [HttpGet("email")]
        public IActionResult GetByEmail(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                return NotFound(); // Retorna 404 se não for encontrada
            }
            return Ok(user); // Retorna 200 com os dados da categoria
        }

        //Para criar users Admin a partir da API
        [HttpPost]
        public IActionResult SaveUser(User user)
        {
            try
            {
                // Verifica se o email dd utilizador já existe, pois este é um campo único
                if (_userService.UserExists(user.Email))
                {
                    return Conflict("This email already exists."); // 409 Conflict
                }

                // Hash a password antes de armazenar
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                // Criar novo utilizador
                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Admin = user.Admin,
                    Password = passwordHash // Armazenar o hash da password
                };

                _userService.SaveUser(newUser); // Chama o serviço para criar o utilizador

                // Retorna o CreatedAtAction com o email do novo utilizador
                return CreatedAtAction(nameof(Register), new { Email = newUser.Email });
            }
            catch (InvalidOperationException ex)
            {
                // Quando o email já estiver em uso, retornar 409 Conflict com uma mensagem personalizada
                return Conflict(new { message = "The email provided is already in use. Please try another one." });
            }
            catch (Exception ex)
            {
                // Outras exceções - retorna 500 Internal Server Error com uma mensagem genérica
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }



        [HttpPut]
        public IActionResult UpdateUserAdmin([FromBody] User user)
        {
            try
            {
                var existingUser = _userService.GetById(user.Id);

                if (existingUser == null)
                {
                    return NotFound(new { error = "User not found." });
                }

                existingUser.Admin = user.Admin;

                _userService.UpdateUser(existingUser);

                return Ok(new { message = "User updated successfully." }); // Retorna um objeto JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Internal server error: {ex.Message}" });
            }
        }





        //Para registar users NÂO Admin na app

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            try
            {
                // Verifica se o nome de utilizador já existe
                if (_userService.UserExists(user.Email))
                {
                    return Conflict("This email already exists."); // 409 Conflict
                }

                // Hash a password antes de armazenar
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                // Criar novo utilizador
                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Admin = false,
                    Password = passwordHash // Armazenar o hash da password
                };

                _userService.SaveUser(newUser); // Chama o serviço para criar o utilizador

                // Retorna o CreatedAtAction com o email do novo utilizador
                return CreatedAtAction(nameof(Register), new { Email = newUser.Email });
            }
            catch (InvalidOperationException ex)
            {
                // Quando o email já estiver em uso, retornar 409 Conflict com uma mensagem personalizada
                return Conflict(new { message = "The email provided is already in use. Please try another one." });
            }
            catch (Exception ex)
            {
                // Outras exceções - retorna 500 Internal Server Error com uma mensagem genérica
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                // Tenta validar o utilizador
                var userLogin = _userService.ValidateUser(user.Email, user.Password);
                if (userLogin == null)
                {
                    // Retorna Unauthorized (401) se as credenciais estiverem erradas
                    return Unauthorized(new { message = "Email ou password inválidos." });
                }

                // Gera o token JWT
                var token = GenerateJwtToken(userLogin);

                // Retorna o token e dados adicionais do utilizador
                return Ok(new
                {
                    
                    Token = token,
                    Name = userLogin.Name,
                    Admin = userLogin.Admin,
                    Id = userLogin.Id
                });
            }
            catch (InvalidOperationException ex)
            {
                // Captura erros específicos de operação
                // Log da exceção
                Console.WriteLine($"Erro de operação: {ex.Message}");
                return Conflict(new { message = "Ocorreu um problema durante o login. Por favor, tente novamente." });
            }
            catch (Exception ex)
            {
                // Captura exceções inesperadas

                // Log da exceção
                Console.WriteLine($"Erro de operação: {ex.Message}");
                return StatusCode(500, new { message = "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde." });
            }
        }





        private string GenerateJwtToken(User userLogin)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY"))); // Read key from environment variable
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _userService.RemoveUser(id);
        }

    }
}


using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Implementations;
using iRecipeAPI.Repositories.Interfaces;
using iRecipeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using BCrypt;

namespace iRecipeAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IUserRepository _userRepository;
        private IFavouriteRepository _favouriteRepository;
        private ICommentRepository _commentRepository;

        public UserService(iRecipeAPIDBContext irecipeAPIDBContext, IUserRepository userRepository, IFavouriteRepository favouriteRepository, ICommentRepository commentRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _userRepository = userRepository;
            _favouriteRepository = favouriteRepository;
            _commentRepository = commentRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public bool UserExists(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return user != null; //Retorna true se o utilizador existir;
        }

        public User SaveUser(User user)
        {
            bool userExists = _userRepository.GetAny(user.Id);

            if (!userExists)
            {
                user = _userRepository.Add(user);
            }
            else
            {
                user = _userRepository.Update(user);
            }

            //_irecipeAPIDBContext.SaveChanges();
            return user;
        }

        public void UpdateUser(User user)
        {
            // Atualiza o usuário no repositório
            _userRepository.Update(user);
        }


        // Método para validar o utilizador
        public User ValidateUser(string email, string password)
        {
            var user = _userRepository.GetByEmail(email); // Obtém o utilizador pelo nome de utilizador
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password)) // Verifica se a password corresponde ao hash
            {
                return user; // Retorna o utilizador se a validação for bem-sucedida
            }
            return null; // Retorna null se a validação falhar
        }

        public void RemoveUser(int id)
        {
            try
            {
                User userResult = _userRepository.GetById(id);

                if (userResult == null)
                {
                    throw new InvalidOperationException($"Usuário com ID {id} não foi encontrado.");
                }

                // Verificar se o usuário tem favoritos antes de tentar remover
                var favourites = _favouriteRepository.GetAllByUserId(id);
                if (favourites.Any())
                {
                    foreach (var favourite in favourites)
                    {
                        _favouriteRepository.Remove(favourite);
                    }
                }

                // Verificar se o usuário tem comentários antes de tentar remover
                var comments = _commentRepository.GetAllByUserId(id);
                if (comments.Any())
                {
                    foreach (var comment in comments)
                    {
                        _commentRepository.Remove(comment);
                    }
                }

                // Depois de remover os favoritos e comentários, exclua o usuário
                _userRepository.Remove(userResult);
            }
            catch (InvalidOperationException ex)
            {
                // Tratamento específico para usuário não encontrado
                Console.WriteLine($"Erro: {ex.Message}");
                // Lançar exceção ou retornar uma mensagem apropriada para o controlador ou serviço
                throw;
            }
            catch (Exception ex)
            {
                // Tratamento genérico de exceção
                Console.WriteLine($"Erro inesperado ao tentar remover o usuário: {ex.Message}");
                // Lançar exceção ou retornar uma mensagem apropriada
                throw;
            }
        }


    }

}

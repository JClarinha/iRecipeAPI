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

namespace iRecipeAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IUserRepository _userRepository;

        public UserService(iRecipeAPIDBContext irecipeAPIDBContext, IUserRepository userRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
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

            _irecipeAPIDBContext.SaveChanges();
            return user;
        }

        public void RemoveUser(int id)
        {
            User userResult = _userRepository.GetById(id);
            if (userResult != null)
            {
                _userRepository.Remove(userResult);
                _irecipeAPIDBContext.SaveChanges();
            }
        }

    }
}

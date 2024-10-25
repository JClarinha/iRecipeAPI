using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByEmail(string Email);
        bool UserExists(string email);
        User SaveUser(User user);
        void UpdateUser(User user);
        User ValidateUser(string Email, string Password);
        void RemoveUser(int id);
    }
}


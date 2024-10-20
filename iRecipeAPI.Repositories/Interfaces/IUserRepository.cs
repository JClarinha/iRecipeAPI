using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        bool GetAny(int id);
        List<User> GetByEmail(string email);
        User Add(User user);
        User Update(User user);
        void Remove(User User);
    }
}

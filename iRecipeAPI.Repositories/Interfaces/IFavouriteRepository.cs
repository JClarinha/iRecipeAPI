using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Interfaces
{
    public interface IFavouriteRepository
    {
        List<Favourite> GetAll();
        List<Favourite> GetAllByUser(User user);
        Favourite GetById(int id);
        bool GetAny(int id);
        Favourite Add(Favourite favourite);
        void Remove(Favourite favourite);
    }
}

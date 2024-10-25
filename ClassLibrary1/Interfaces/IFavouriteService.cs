using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface IFavouriteService
    {
        List<Favourite> GetAll();
        Favourite GetById(int id);
        Favourite SaveFavourite(Favourite favourite);
        List<Favourite> GetAllByUserId(int userId);
        void RemoveFavourite(int id);
    }
}


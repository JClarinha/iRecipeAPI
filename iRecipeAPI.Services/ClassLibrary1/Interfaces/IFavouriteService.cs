using iRecipe.Domain;
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
        Favourite GetbyId(int id);
        Favourite SaveFavourite(Favourite favourite); //Não tenho a certeza se não tem de ser int recipeId!
        Favourite RemoveFavourite(int id);

    }
}

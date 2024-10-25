using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetAll();
        Recipe GetById(int id);
        List<Recipe> GetByUserId(int Userid);
        Recipe SaveRecipe(Recipe recipe);
        Recipe UpdateRecipe(Recipe recipe);
        void RemoveRecipe(int id);
    }
}

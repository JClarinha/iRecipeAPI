using iRecipe.Domain;
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
        Recipe SaveRecipe(Recipe recipe);
        Recipe RemoveRecipe(int id);
    }
}

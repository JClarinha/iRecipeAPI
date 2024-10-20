using iRecipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface IIngerdientService
    {
        List<Ingredient> GetAll();
        Ingredient GetById(int id);
        Ingredient SaveIngredient(Ingredient ingredient);
        Ingredient RemoveIngredient(int id);  
    }
}

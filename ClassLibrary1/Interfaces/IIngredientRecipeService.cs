using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface IIngredientRecipeService
    {
        List<IngredientRecipe> GetAll();
        List<IngredientRecipe> GetAllByRecipeId(int recipeId);
        IngredientRecipe GetById(int id);

        IngredientRecipe SaveIngredientRecipe(IngredientRecipe ingredientRecipe);
        void RemoveIngredientRecipe(int id);
    }
}

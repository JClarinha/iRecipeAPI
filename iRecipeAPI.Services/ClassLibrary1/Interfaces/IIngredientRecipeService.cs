using iRecipe.Domain;
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
        IngredientRecipe SeveIngredientRecipe(IngredientRecipe ingredientRecipe);
        IngredientRecipe RemoveIngredientRecipe(int id);

    }
}

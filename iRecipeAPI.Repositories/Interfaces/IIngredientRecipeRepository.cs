using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Interfaces
{
    public interface IIngredientRecipeRepository
    {

        List<IngredientRecipe> GetAll();
        List<IngredientRecipe> GetAllByRecipeId(int recipeId);
        IngredientRecipe GetById(int id);
        IngredientRecipe Add(IngredientRecipe ingredientRecipe);
        IngredientRecipe Update(IngredientRecipe ingredientRecipe);
        void Remove(IngredientRecipe ingredientRecipe);
    }
}

using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Implementations;
using iRecipeAPI.Repositories.Interfaces;
using iRecipeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IRecipeRepository _recipeRepository;
        private IIngredientRecipeRepository _ingredientRecipeRepository;


        public RecipeService(iRecipeAPIDBContext irecipeAPIDBContext, IRecipeRepository recipeRepository) //IIngredientRecipeRepository ingredientRecipeRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _recipeRepository = recipeRepository;
        }


        public List<Recipe> GetAll()
        {
            return _recipeRepository.GetAll();
        }

        public Recipe GetById(int id)
        {
            return _recipeRepository.GetById(id);
        }

        public Recipe SaveRecipe(Recipe recipe)
        {
            bool recipeExists = _recipeRepository.GetAny(recipe.Id);

            if (!recipeExists)
            {
                recipe = _recipeRepository.Add(recipe);
            }
           /* else
            {
                recipe = _recipeRepository.Update(recipe);
            }*/

            return recipe;
        }

        public void RemoveRecipe(int id)
        {
            Recipe recipeResult = _recipeRepository.GetById(id);
            if (recipeResult != null)
            {
                _recipeRepository.Remove(recipeResult);
                _irecipeAPIDBContext.SaveChanges();
            }
        }
    }
}

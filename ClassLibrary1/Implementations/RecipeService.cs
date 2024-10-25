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

        public List<Recipe> GetByUserId(int Userid)
        {
            return _recipeRepository.GetByUserId(Userid);
        }

        public Recipe SaveRecipe(Recipe recipe)
        {
            bool recipeExists = _recipeRepository.GetAny(recipe.Id);

            if (!recipeExists)
            {
                recipe = _recipeRepository.Add(recipe);
            }
            /*
           else
            {
                recipe = _recipeRepository.Update(recipe);
            }*/

            return recipe;
        }

        public Recipe UpdateRecipe(Recipe recipe)
        {
            var existingRecipe = _recipeRepository.GetById(recipe.Id);

            if (existingRecipe == null)
            {
                throw new Exception("Receita não encontrada.");
            }

            // Atualiza os campos da receita existente
            existingRecipe.Name = recipe.Name;
            existingRecipe.Description = recipe.Description;
            existingRecipe.Pax = recipe.Pax;
            existingRecipe.CategoryId = recipe.CategoryId;
            existingRecipe.DifficultyId = recipe.DifficultyId;
            existingRecipe.Duration = recipe.Duration;
            existingRecipe.Preparation = recipe.Preparation;
            existingRecipe.ImagePath = recipe.ImagePath; // Atualiza apenas se o ImagePath for modificado
            existingRecipe.Approval = recipe.Approval;
            existingRecipe.UserId = recipe.UserId;
            existingRecipe.RecipeDate = recipe.RecipeDate;

            // Atualiza a receita no repositório
            _recipeRepository.Update(existingRecipe);
            return existingRecipe;
        }

        public void RemoveRecipe(int id)
        {
            Recipe recipeResult = _recipeRepository.GetById(id);
            if (recipeResult != null)
            {
                _recipeRepository.Remove(recipeResult);
            }
        }
    }
}

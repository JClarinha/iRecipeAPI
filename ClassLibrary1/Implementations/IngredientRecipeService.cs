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
    public class IngredientRecipeService : IIngredientRecipeService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IIngredientRecipeRepository _ingredientRecipeRepository;


        public IngredientRecipeService(iRecipeAPIDBContext irecipeAPIDBContext, IIngredientRecipeRepository ingredientRecipeRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _ingredientRecipeRepository = ingredientRecipeRepository;
        }




        public List<IngredientRecipe> GetAll()
        {
            return _ingredientRecipeRepository.GetAll();
        }

        public List<IngredientRecipe> GetAllByRecipeId(int recipeId)
        {
            return _ingredientRecipeRepository.GetAllByRecipeId(recipeId);
        }

        public IngredientRecipe GetById(int id)
        {
            return _ingredientRecipeRepository.GetById(id);
        }

        /*
        public IngredientRecipe SaveIngredientRecipe(IngredientRecipe ingredientRecipe)
        {
            IngredientRecipe ingredientRecipeResult = _ingredientRecipeRepository.GetById(ingredientRecipe.Id);

            ingredientRecipe.Ingredient = null;
            ingredientRecipe.Recipe = null;

            
            if (ingredientRecipeResult == null)
            {
                ingredientRecipe = _ingredientRecipeRepository.Add(ingredientRecipe);
            }
            else
            {
                ingredientRecipe = _ingredientRecipeRepository.Update(ingredientRecipe);
            }

            _irecipeAPIDBContext.SaveChanges();

            return ingredientRecipe;
        }
        */
        
      
            public IngredientRecipe SaveIngredientRecipe(IngredientRecipe ingredientRecipe)
        {

            var existingIngredientRecipe = _ingredientRecipeRepository.GetById(ingredientRecipe.Id);


            ingredientRecipe.Ingredient = null;
            ingredientRecipe.Recipe = null;


            if (existingIngredientRecipe == null)
                {
                    _ingredientRecipeRepository.Add(ingredientRecipe);
                }
                else
                {
                    _ingredientRecipeRepository.Update(ingredientRecipe);
                }

                return ingredientRecipe;
            }
       

        public void RemoveIngredientRecipe(int id)
        {
            IngredientRecipe ingredientRcipeResult = _ingredientRecipeRepository.GetById(id);

            if (ingredientRcipeResult != null)
            {
                _ingredientRecipeRepository.Remove(ingredientRcipeResult);

                _irecipeAPIDBContext.SaveChanges();
            }
        }

    }
}

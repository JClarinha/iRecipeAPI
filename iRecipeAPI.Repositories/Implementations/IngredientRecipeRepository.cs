using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Implementations
{
    public class IngredientRecipeRepository : IIngredientRecipeRepository
    {
        private readonly DbSet<IngredientRecipe> _dbSet;
        private readonly iRecipeAPIDBContext _irecipeAPIDBContext;

        public IngredientRecipeRepository(iRecipeAPIDBContext irecipeAPIDBContext)
        {
            _dbSet = irecipeAPIDBContext.Set<IngredientRecipe>();
            _irecipeAPIDBContext = irecipeAPIDBContext;
        }

        public List<IngredientRecipe> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<IngredientRecipe> GetAllByRecipeId(int recipeId)
        {
            return _dbSet.Where(p => p.RecipeId == recipeId).Include(p => p.Ingredient).Include(p => p.Unit).ToList();
        }

        public IngredientRecipe GetById(int id)
        {
            return _dbSet
                .Where(p => p.Id == id)
                .Include(p => p.Recipe)
                .ThenInclude(p => p.User)
                .Include(p => p.Ingredient)
                .FirstOrDefault();
        }

        public IngredientRecipe Add(IngredientRecipe ingredinentRecipe)
        {
            _dbSet.Add(ingredinentRecipe);
            _irecipeAPIDBContext.SaveChanges();
            return ingredinentRecipe;
        }

        public IngredientRecipe Update(IngredientRecipe ingredientRecipe)
        {
            _dbSet .Update(ingredientRecipe);
            _irecipeAPIDBContext.SaveChanges();
            return ingredientRecipe;
        }

        public void Remove(IngredientRecipe ingredientRecipe)
        {
            _dbSet.Remove(ingredientRecipe);
            _irecipeAPIDBContext.SaveChanges();

        }
    }
}

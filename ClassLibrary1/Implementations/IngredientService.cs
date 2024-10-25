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
    public class IngredientService : IIngredientService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IIngredientRepository _ingredientRepository;


        public IngredientService(iRecipeAPIDBContext irecipeAPIDBContext, IIngredientRepository ingredientRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _ingredientRepository = ingredientRepository;
        }


        public List<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient GetById(int id)
        {
            return _ingredientRepository.GetById(id);
        }

        public Ingredient GetByName(string name)
        {
            return _ingredientRepository.GetByName(name);
        }

        public Ingredient SaveIngredient(Ingredient ingredient)
        {
            bool ingredientExists = _ingredientRepository.GetAny(ingredient.Id);

            if (!ingredientExists)
            {
                ingredient = _ingredientRepository.Add(ingredient);
            }
            else
            {
                ingredient = _ingredientRepository.Update(ingredient);
            }

            return ingredient;
        }

        public Ingredient GetOrCreateIngredient(string name)
        {
            // Verifica se o ingrediente já existe pelo nome
            var existingIngredient = _ingredientRepository.GetByName(name);

            if (existingIngredient != null)
            {
                // Se o ingrediente já existir, retorna-o
                return existingIngredient;
            }

            // Se o ingrediente não existir, cria um novo
            var newIngredient = new Ingredient
            {
                Name = name
            };

            // Adiciona o novo ingrediente ao repositório
            _ingredientRepository.Add(newIngredient);


            // Retorna o novo ingrediente criado
            return newIngredient;
        }


        public void RemoveIngredient(int id)
        {
            Ingredient ingredientResult = _ingredientRepository.GetById(id);
            if (ingredientResult != null)
            {
                _ingredientRepository.Remove(ingredientResult);
            }
        }
    }
}

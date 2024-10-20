using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        List<Ingredient> GetAll();
        Ingredient GetById(int id);
        bool GetAny(int id);
        Ingredient GetByName(string name);
        Ingredient Add(Ingredient ingredient);  
        Ingredient Update(Ingredient ingredient);
        void Remove(Ingredient ingredient);
    }
}

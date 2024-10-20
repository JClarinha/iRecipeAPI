using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRecipeAPI.Domain;


namespace iRecipeAPI.Repositories.Interfaces
{
    public  interface IRecipeRepository
    {
        List<Recipe> GetAll();
        Recipe GetById(int id);
        bool GetAny(int id);
        Recipe GetLast();
        List<Recipe> GetByName(string name);
        Recipe Add(Recipe recipe);
        Recipe Update(Recipe recipe);
        void Remove(Recipe recipe);


    }
}

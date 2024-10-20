using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        bool GetAny(int id);
        List<Category> GetByName(string name);
        Category Add(Category category);
        Category Update(Category category);
        void Remove(Category category);
    }
}

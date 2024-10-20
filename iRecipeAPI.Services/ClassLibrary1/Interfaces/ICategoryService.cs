using iRecipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category SaveCategory(Category category);
        Category RemoveCategory(int id);
    }
}

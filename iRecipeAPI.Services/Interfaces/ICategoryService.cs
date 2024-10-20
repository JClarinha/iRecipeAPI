using System.Collections.Generic;

namespace iRecipeAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
    }
}

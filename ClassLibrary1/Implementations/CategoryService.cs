using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Interfaces;
using iRecipeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private ICategoryRepository _categoryRepository;

        public CategoryService(iRecipeAPIDBContext irecipeAPIDBContext, ICategoryRepository categoryRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category SaveCategory(Category category)
        {
            bool categoryExists = _categoryRepository.GetAny(category.Id);

            if (!categoryExists)
            {
                category = _categoryRepository.Add(category);
            }
          /*  else
            {
                category = _categoryRepository.Update(category);
            }
          */
            return category;
        }

        public void RemoveCategory(int id)
        {
            Category categoryResult = _categoryRepository.GetById(id);
            if (categoryResult != null)
            {
                _categoryRepository.Remove(categoryResult);
                _irecipeAPIDBContext.SaveChanges();
            }
        }


    }
}

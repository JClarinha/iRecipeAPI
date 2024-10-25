using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace iRecipeAPI.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> _dbSet;
        private readonly iRecipeAPIDBContext _iRecipeAPIDBContext;



        public CategoryRepository(iRecipeAPIDBContext irecipeApiDBContext)
        {
            _dbSet = irecipeApiDBContext.Set<Category>();
            _iRecipeAPIDBContext = irecipeApiDBContext;

        }

        public List<Category> GetAll()
        {
            return _dbSet.ToList(); // SELECT * FROM Category
        }

        public Category GetById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id); //SELECT * FROM Category WHERE iD = ID;
        }

        public bool GetAny(int id)
        {
            return _dbSet.Any(category => category.Id == id);
        }

        public List <Category> GetByName(string name) 
        {
           return _dbSet.Where(category => category.Name.Contains(name)).ToList(); // SELECT / FROM Category WHERE Name LIKE '%name%';          
        }

        public Category Add(Category category)
        {
            _dbSet.Add(category); //INSERT INTO Category (Colums) VALUES (values);
            _iRecipeAPIDBContext.SaveChanges();
            return category;
        }

        public Category Update(Category category) 
        {
            _dbSet.Update(category); // UPDATE Category SET Colum = Value, ...;
            _iRecipeAPIDBContext.SaveChanges();

            return category ;
        }

        public void Remove(Category category) 
        {
            _dbSet.Remove(category);//DELETE FROM Category 
            _iRecipeAPIDBContext.SaveChanges();

        }



    }
}

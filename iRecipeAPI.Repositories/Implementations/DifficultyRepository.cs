using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iRecipeAPI.Repositories.Implementations
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly DbSet<Difficulty> _dbSet;
        private readonly iRecipeAPIDBContext _iRecipeAPIDBContext;


        public DifficultyRepository(iRecipeAPIDBContext irecipeAPIDBContext)
        {
            _dbSet = irecipeAPIDBContext.Set<Difficulty>();
            _iRecipeAPIDBContext = irecipeAPIDBContext;
        }

        public List<Difficulty> GetAll()
        {
            return _dbSet.ToList();
        }

        public Difficulty GetById(int id)
        {
            return _dbSet.FirstOrDefault(difficulty => difficulty.Id ==id);
        }

        public bool GetAny(int id)
        {
            return _dbSet.Any(difficulty => difficulty.Id == id);
        }

        public List<Difficulty> GetByDifficultyLevel(string difficultyLevel)
        {
            return _dbSet.Where(difficulty => difficulty.DifficultyLevel.Contains(difficultyLevel)).ToList();
        }
        
        public Difficulty Add(Difficulty difficulty)
        {
            _dbSet.Add(difficulty);
            _iRecipeAPIDBContext.SaveChanges();

            return difficulty;
        }

        public Difficulty Update(Difficulty difficulty)
        {
            _dbSet.Update(difficulty);
            _iRecipeAPIDBContext.SaveChanges();

            return difficulty;
        }

        public void Remove(Difficulty difficulty)
        {
            _dbSet.Remove(difficulty);
        }

    }
}

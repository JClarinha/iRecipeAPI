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
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly DbSet<Favourite> _dbSet;
        private readonly iRecipeAPIDBContext _iRecipeAPIDBContext;


        public FavouriteRepository(iRecipeAPIDBContext irecipeAPIDBContext)
        {
            _dbSet = irecipeAPIDBContext.Set<Favourite>();
            _iRecipeAPIDBContext = irecipeAPIDBContext;

        }

        public List<Favourite> GetAll()
        {
            return _dbSet.ToList();
        }

        public Favourite GetById(int id)
        {
            return _dbSet.FirstOrDefault(favourite => favourite.Id == id); //SELECT / FROM Category WHERE iD = ID;
        }


        public List<Favourite> GetAllByUserId(int userId)
        {
            return _dbSet.Where(p => p.UserId == userId).Include(p => p.User).Include(p => p.Recipe).ToList();
        }

        public bool GetAny(int id)
        {
            return _dbSet.Any(favourite => favourite.Id == id);
        }

        public Favourite Add(Favourite favourite)
        {
            _dbSet.Add(favourite);
            _iRecipeAPIDBContext.SaveChanges();
            return favourite;
        }

        public void Remove(Favourite favourite)
        {
            _dbSet.Remove(favourite);
            _iRecipeAPIDBContext.SaveChanges();

        }




    }
}

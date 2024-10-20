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
    public class UnitRepository : IUnitRepository
    {
        private readonly DbSet<Unit> _dbSet;
        private readonly iRecipeAPIDBContext _iRecipeAPIDBContext;


        public UnitRepository (iRecipeAPIDBContext irecipeAPIDBContext)
        {
            _dbSet = irecipeAPIDBContext.Set<Unit>();
            _iRecipeAPIDBContext = irecipeAPIDBContext;

        }

        public List<Unit> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<Unit> GetByName (string name)
        {
            return _dbSet.Where(unit => unit.Name.Contains(name)).ToList();
        }

        public Unit GetById (int id)
        {
            return _dbSet.FirstOrDefault(unit => unit.Id == id);

        }

        public bool GetAny(int id)
        {
            return _dbSet.Any(unit => unit.Id == id);
        }

        public Unit Add(Unit unit) 
        { 
            _dbSet.Add(unit);
            _iRecipeAPIDBContext.SaveChanges();

            return unit;
        }

        public Unit Update(Unit unit)
        {
            _dbSet.Update(unit);
            _iRecipeAPIDBContext.SaveChanges();

            return unit;
        }

        public void Remove(Unit unit)
        {
            _dbSet.Remove(unit);

        }
    }
}

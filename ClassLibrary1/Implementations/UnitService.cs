using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Implementations;
using iRecipeAPI.Repositories.Interfaces;
using iRecipeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Implementations
{
    public class UnitService : IUnitService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IUnitRepository _unitRepository;


        public UnitService(iRecipeAPIDBContext irecipeAPIDBContext, IUnitRepository unitRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _unitRepository = unitRepository;
        }


        public List<Unit> GetAll()
        {
            return _unitRepository.GetAll();
        }

        public Unit GetById(int id)
        {
            return _unitRepository.GetById(id);
        }

        public Unit SaveUnit(Unit unit)
        {
            bool unitExists = _unitRepository.GetAny(unit.Id);

            if (!unitExists)
            {
                unit = _unitRepository.Add(unit);
            }
            else
            {
                unit = _unitRepository.Update(unit);
            }

            _irecipeAPIDBContext.SaveChanges();
            return unit;
        }

        public void RemoveUnit(int id)
        {
            Unit unitResult = _unitRepository.GetById(id);
            if (unitResult != null)
            {
                _unitRepository.Remove(unitResult);
                _irecipeAPIDBContext.SaveChanges();
            }
        }
    }
}

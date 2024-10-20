using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface IUnitService
    {
        List<Unit> GetAll();
        Unit GetById(int id);
        Unit SaveUnit(Unit unit);
        void RemoveUnit(int id);
    }
}

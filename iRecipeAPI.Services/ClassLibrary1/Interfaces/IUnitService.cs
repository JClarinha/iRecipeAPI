using iRecipe.Domain;
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
        Unit GetByName(string name);
        Unit SaveUnit(Unit unit);
        Unit RemoveUnit(int id);
    }
}

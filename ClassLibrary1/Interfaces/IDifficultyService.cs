using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface IDifficultyService
    {
        List<Difficulty> GetAll();
        Difficulty GetById(int id);
        Difficulty SaveDifficulty(Difficulty difficulty);
        void RemoveDifficulty(int id);
    }
}


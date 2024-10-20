using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Interfaces
{
    public interface IDifficultyRepository
    {
        List<Difficulty> GetAll();
        Difficulty GetById(int id);
        bool GetAny(int id);
        List<Difficulty> GetByDifficultyLevel(string difficultyLevel);
        Difficulty Add(Difficulty difficulty);
        Difficulty Update(Difficulty difficulty);   
        void Remove(Difficulty difficulty);
    }
}

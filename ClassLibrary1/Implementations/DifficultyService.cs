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
    public class DifficultyService : IDifficultyService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IDifficultyRepository _difficultyRepository;

        public DifficultyService(iRecipeAPIDBContext irecipeAPIDBContext, IDifficultyRepository difficultyRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _difficultyRepository = difficultyRepository;
        }



        public List<Difficulty> GetAll()
        {
            return _difficultyRepository.GetAll();
        }

        public Difficulty GetById(int id)
        {
            return _difficultyRepository.GetById(id);
        }

        public Difficulty SaveDifficulty(Difficulty difficulty)
        {
            bool difficultyExists = _difficultyRepository.GetAny(difficulty.Id);

            if (!difficultyExists)
            {
                difficulty = _difficultyRepository.Add(difficulty);
            }
            else
            {
                difficulty = _difficultyRepository.Update(difficulty);
            }

            _irecipeAPIDBContext.SaveChanges();
            return difficulty;
        }

        public void RemoveDifficulty(int id)
        {
            Difficulty difficultyResult = _difficultyRepository.GetById(id);
            if (difficultyResult != null)
            {
                _difficultyRepository.Remove(difficultyResult);
                _irecipeAPIDBContext.SaveChanges();
            }
        }

    }
}

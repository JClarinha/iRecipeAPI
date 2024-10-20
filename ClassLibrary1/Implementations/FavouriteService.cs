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
    public class FavouriteService : IFavouriteService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private IFavouriteRepository _favouriteRepository;


        public FavouriteService(iRecipeAPIDBContext irecipeAPIDBContext, IFavouriteRepository favouriteRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _favouriteRepository = favouriteRepository;
        }


        public List<Favourite> GetAll()
        {
            return _favouriteRepository.GetAll();
        }

        public List<Favourite> GetAllByUser(User user)
        {
            return _favouriteRepository.GetAllByUser(user);
        }

        public Favourite GetById(int id)
        {
            return _favouriteRepository.GetById(id);
        }

        public Favourite SaveFavourite(Favourite favourite)
        {
            bool FavouriteExists = _favouriteRepository.GetAny(favourite.Id);

            if (!FavouriteExists)
            {
                favourite = _favouriteRepository.Add(favourite);
            }

            _irecipeAPIDBContext.SaveChanges();
            return favourite;
        }

        public void RemoveFavourite(int id)
        {
            Favourite FavouriteResult = _favouriteRepository.GetById(id);
            if (FavouriteResult != null)
            {
                _favouriteRepository.Remove(FavouriteResult);
                _irecipeAPIDBContext.SaveChanges();
            }
        }

    }
}

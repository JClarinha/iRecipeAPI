using iRecipeAPI.Domain;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iRecipeAPI.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbSet<Comment> _dbSet;
        private readonly iRecipeAPIDBContext _iRecipeAPIDBContext;


        public CommentRepository(iRecipeAPIDBContext irecipeAPIDBContext)
        {
            _dbSet = irecipeAPIDBContext.Set<Comment>();
            _iRecipeAPIDBContext = irecipeAPIDBContext;
        }

        public List<Comment> GetAll() 
        {
            return _dbSet.ToList();        
        }

        public Comment GetById(int id)
        {
            return _dbSet.FirstOrDefault(comment => comment.Id == id);
        }
        public bool GetAny(int id)
        {
            return _dbSet.Any(comment => comment.Id == id);
        }


        public List<Comment> GetAllByUserId(int userId)
        {
            return _dbSet.Where(p => p.UserId == userId).Include(p => p.User).Include(p => p.Recipe).ToList();
        }


        public Comment Add(Comment comment)
        {
            _dbSet.Add(comment);
            _iRecipeAPIDBContext.SaveChanges();
            return comment;
        }

        public Comment Update(Comment comment)
        {
            _dbSet.Update(comment);
            _iRecipeAPIDBContext.SaveChanges();

            return comment;
        }

        public void Remove(Comment comment)
        {
            _dbSet.Remove(comment);
            _iRecipeAPIDBContext.SaveChanges();

        }
    }

}

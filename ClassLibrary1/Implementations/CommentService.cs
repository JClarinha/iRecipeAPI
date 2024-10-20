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
    public class CommentService : ICommentService
    {
        private iRecipeAPIDBContext _irecipeAPIDBContext;
        private ICommentRepository _commentRepository;

        public CommentService(iRecipeAPIDBContext irecipeAPIDBContext, ICommentRepository commentRepository)
        {
            _irecipeAPIDBContext = irecipeAPIDBContext;
            _commentRepository = commentRepository;
        }

        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public Comment SaveComment(Comment Comment)
        {
            bool CommentExists = _commentRepository.GetAny(Comment.Id);

            if (!CommentExists)
            {
                Comment = _commentRepository.Add(Comment);
            }
            else
            {
                Comment = _commentRepository.Update(Comment);
            }

            _irecipeAPIDBContext.SaveChanges();
            return Comment;
        }

        public void RemoveComment(int id)
        {
            Comment commentResult = _commentRepository.GetById(id);
            if (commentResult != null)
            {
                _commentRepository.Remove(commentResult);
                _irecipeAPIDBContext.SaveChanges();
            }
        }

    }
}

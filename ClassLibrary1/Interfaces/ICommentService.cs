using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Services.Interfaces
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment GetById(int id);
        Comment SaveComment(Comment comment);
        void RemoveComment(int id);
    }
}

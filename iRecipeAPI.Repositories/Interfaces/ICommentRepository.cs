using iRecipeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();
        Comment GetById(int id);
        bool GetAny(int id);
        Comment Add(Comment comment);
        Comment Update(Comment comment);
        void Remove(Comment comment);
    }
}

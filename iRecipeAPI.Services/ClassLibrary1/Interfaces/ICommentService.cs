using iRecipe.Domain;
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
        Comment RemoveComment(int id);
    }
}

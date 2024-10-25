using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Domain
{
    public class Favourite
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}

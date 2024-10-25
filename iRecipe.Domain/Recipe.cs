using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRecipeAPI.Domain
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Pax { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool? Approval { get; set; }
        public int Duration { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime? RecipeDate { get; set; }
        public int DifficultyId { get; set; }
        public Difficulty? Difficulty { get; set; }
  
        public string Preparation { get; set; }

       




        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
        

        
    }

}

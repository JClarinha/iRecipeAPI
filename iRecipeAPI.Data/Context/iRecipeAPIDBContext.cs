using iRecipeAPI.Domain;
using Microsoft.EntityFrameworkCore;



namespace iRecipeAPI.Data.Context
{

    public class iRecipeAPIDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Recipe> Recepies { get; set; }
        public DbSet<IngredientRecipe> IngredientRecepies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Favourite> Favorits { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Clarinha_Laptop\\SQLEXPRESS; Database=iRecipe;Trusted_Connection=True;integrated security=true; TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .IsRequired(); // Define que Name é obrigatório

            modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired(); // Define que Email é obrigatório

            modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .IsRequired(); // Define que Password é obrigatório

            modelBuilder.Entity<User>()
            .Property(u => u.Admin)
            .IsRequired(); // Define que Admin é obrigatório

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique(); // Define o campo Email como único



            // Relacionamento entre Comment e Recipe
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Recipe)
                .WithMany() // Sem navegação inversa
                .HasForeignKey(c => c.RecipeId)
                .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata permitida para Recipes

            // Relacionamento entre Comment e User
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany() // Sem navegação inversa
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Impede cascata na exclusão de Users


             //Configurando a tabela de junção FavoriteRecipe
            modelBuilder.Entity<Favourite>()
                .HasKey(f => new { f.UserId, f.RecipeId }); // Chave composta

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany() // Sem navegação inversa em User
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Cascata na exclusão de usuários



            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.Recipe)
                .WithMany() // Sem navegação inversa em Recipe
                .HasForeignKey(f => f.RecipeId)
                .OnDelete(DeleteBehavior.Cascade); // Cascata na exclusão de receitas
            
            
        modelBuilder.Entity<Category>()
               .Property(r => r.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Comment>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Difficulty>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Favourite>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ingredient>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<IngredientRecipe>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Unit>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();


        }

    }

}









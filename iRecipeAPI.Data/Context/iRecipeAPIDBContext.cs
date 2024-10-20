using iRecipeAPI.Domain;
using Microsoft.EntityFrameworkCore;



namespace iRecipeAPI.Data.Context
{


    /*public class iRecipeAPIDBContext : DbContext
    {
        public iRecipeAPIDBContext(DbContextOptions<iRecipeAPIDBContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favourite> Favourites { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Clarinha_Laptop\\SQLEXPRESS; Database=iRecipe;Trusted_Connection=True;integrated security=true; TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chave composta para IngredientRecipes
            modelBuilder.Entity<IngredientRecipe>()
                .HasKey(ir => new { ir.IngredientId, ir.RecipeId });

            // Configurar a foreign key entre IngredientRecipes e Recipes
            modelBuilder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Recipe)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(ir => ir.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);  // Remover os ingredientes ao apagar a receita

            // Configurar a foreign key entre IngredientRecipes e Ingredients
            modelBuilder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Ingredient)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(ir => ir.IngredientId);

            // Chave composta para Favorites
            modelBuilder.Entity<Favourite>()
                .HasKey(f => new { f.UserId, f.RecipeId });

            // Configurar relação com Recipe
            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.Recipe)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(f => f.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);  // Remover os favoritos ao apagar a receita

            // Configurar relação com User
            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(f => f.UserId);

            // Configurar relação entre Recipes e Categories
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(r => r.CategoryId);

            // Configurar relação entre Recipes e Difficulties
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Difficulty)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(r => r.DifficultyId);

            // Configurar relação entre Recipes e Users (autor da receita)
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(r => r.UserId);

            // Configurar relação entre Comments e Recipes
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Recipe)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(c => c.RecipeId);

            // Configurar relação entre Comments e Users (autor do comentário)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()  // Sem propriedades de navegação explícitas
                .HasForeignKey(c => c.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }*/


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









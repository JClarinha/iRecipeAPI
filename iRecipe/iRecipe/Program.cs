using Microsoft;
using Microsoft.OpenApi.Models;
using iRecipeAPI.Services.Interfaces;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Data.Context;
using iRecipeAPI.Repositories.Implementations;
using iRecipeAPI.Repositories.Interfaces;

namespace iRecipeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

           /* var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                Args = args,
                WebRootPath = "wwwroot" // Podes substituir "wwwroot" por outro caminho, se necessário.
            });*/



            // Configuração do Serviço do Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "iRecipeAPI",
                    new OpenApiInfo()
                    {
                        Title = "iRecipe Api",
                        Version = "1.0"
                    });
            });

            // Registo da base de dados
            builder.Services.AddScoped<iRecipeAPIDBContext>();

            // Registo de repositórios
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();
            builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            builder.Services.AddScoped<IIngredientRecipeRepository, IngredientRecipeRepository>();
            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            // Registo de serviços
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IDifficultyService, DifficultyService>();
            builder.Services.AddScoped<IFavouriteService, FavouriteService>();
            builder.Services.AddScoped<IIngredientRecipeService, IngredientRecipeService>();
            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IUnitService, UnitService>();
            builder.Services.AddScoped<IUserService, UserService>();



            // Registo dos controladores
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseStaticFiles(); // Necessário para servir ficheiros estáticos do wwwroot


            // Configuração da Interface Gráfica do Swagger
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("iRecipeAPI/Swagger.json", "iRecipe Api");
            });

            app.Run();
        }
    }
}

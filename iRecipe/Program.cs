using Microsoft.OpenApi.Models;

namespace iRecipe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSwaggerGen(Options =>
            {
                Options.SwaggerDoc(
                    "iRecipeAPI",
                    new OpenApiInfo() //Microsoft.OpenApi.Models não está no Orders!!
                    {
                        Title = "iRecipe Api",
                        Version = "1.0.0",
                    });
            });

            // Registo da base de dados
            builder.Services.AddScoped<iRecipeAPIDBContext>();

            // Registo de repositórios
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

        

          

            app.Run();
        }
    }
}

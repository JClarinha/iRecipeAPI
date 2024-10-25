using Microsoft.EntityFrameworkCore;
using Xunit;
using iRecipeAPI.Data.Context; // Certifique-se de ajustar o namespace correto para o DbContext
using iRecipeAPI.Domain;

namespace iRecipe.Testes
{
    public class SimpleInMemoryTest
    {
        [Fact]
        public void Should_Add_Category_To_InMemoryDatabase()
        {
            // Configura o DbContext com o banco de dados InMemory
            var options = new DbContextOptionsBuilder<iRecipeAPIDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Usar o contexto num escopo "using" para garantir que ele é descartado após o uso
            using (var context = new iRecipeAPIDBContext(options))
            {
                // Arrange: Configurar uma nova categoria
                var category = new Category { Name = "Test Category" };

                // Act: Adicionar a categoria e salvar as mudanças
                context.Categories.Add(category);
                context.SaveChanges();

                // Assert: Verificar se a categoria foi salva corretamente
                var categoryFromDb = context.Categories.FirstOrDefault(c => c.Name == "Test Category");
                Assert.NotNull(categoryFromDb);
                Assert.Equal("Test Category", categoryFromDb.Name);
            }
        }
    }
}

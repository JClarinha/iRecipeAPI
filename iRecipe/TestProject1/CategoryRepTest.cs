using iRecipeAPI.Repositories;
using iRecipeAPI.Domain;
using Xunit;
using Moq;
using iRecipeAPI.Repositories.Interfaces;

namespace TestProject1
{
    public class CategoryRepTest
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public CategoryRepTest()
        {
            // Inicializa o mock do repositório
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
        }

        [Fact]
        public void TestAddCategory()
        {
            // Arrange
            var newCategory = new Category { Id = 1, Name = "Appetizer" };

            // Configura o mock para simular a adição da categoria
            _categoryRepositoryMock.Setup(repo => repo.Add(It.IsAny<Category>())).Returns(newCategory);

            // Act
            var result = _categoryRepositoryMock.Object.Add(newCategory);

            // Assert
            Assert.Equal(newCategory.Name, result.Name);
            Assert.Equal(newCategory.Id, result.Id);
        }
    }
}
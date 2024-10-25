using Xunit;
using Moq;
using iRecipeAPI.Domain;
using iRecipeAPI.Repositories.Interfaces;
using iRecipeAPI.Services.Implementations;

namespace iRecipe.Tests
{
    public class UnitServiceTest
    {
        private readonly Mock<IUnitRepository> _unitRepositoryMock;
        private readonly UnitService _unitService;

        public UnitServiceTest()
        {
            // Inicializa o mock do reposit�rio
            _unitRepositoryMock = new Mock<IUnitRepository>();
            
            // Inicializa o servi�o passando o reposit�rio mockado e o contexto (n�o utilizado aqui)
            _unitService = new UnitService(null, _unitRepositoryMock.Object);
        }

        [Fact]
        public void TestSaveUnit_AddsUnit_WhenUnitDoesNotExist()
        {
            // Arrange
            var newUnit = new Unit { Id = 1, Name = "Kilogram" };

            // Simula que a unidade n�o existe
            _unitRepositoryMock.Setup(repo => repo.GetAny(newUnit.Id)).Returns(false);

            // Simula a adi��o da unidade
            _unitRepositoryMock.Setup(repo => repo.Add(It.IsAny<Unit>())).Returns(newUnit);

            // Act
            var result = _unitService.SaveUnit(newUnit);

            // Assert
            Assert.Equal(newUnit.Name, result.Name);
            _unitRepositoryMock.Verify(repo => repo.Add(It.IsAny<Unit>()), Times.Once);
        }

        [Fact]
        public void TestSaveUnit_UpdatesUnit_WhenUnitExists()
        {
            // Arrange
            var existingUnit = new Unit { Id = 1, Name = "Gram" };

            // Simula que a unidade j� existe
            _unitRepositoryMock.Setup(repo => repo.GetAny(existingUnit.Id)).Returns(true);

            // Simula a atualiza��o da unidade
            _unitRepositoryMock.Setup(repo => repo.Update(It.IsAny<Unit>())).Returns(existingUnit);

            // Act
            var result = _unitService.SaveUnit(existingUnit);

            // Assert
            Assert.Equal(existingUnit.Name, result.Name);
            _unitRepositoryMock.Verify(repo => repo.Update(It.IsAny<Unit>()), Times.Once);
        }
    }
}

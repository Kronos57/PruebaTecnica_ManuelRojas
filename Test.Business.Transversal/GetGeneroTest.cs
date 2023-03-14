using Business.Transversal;

namespace Test.Business.Transversal
{
    public class GetGeneroTest
    {
        [Fact]
        public void GetGenero()
        {
            // Data Test
            int idTipoGenero = 2;

            // Arrange
            BusinessUtilsTransversal businessUtilsTransversal  = new BusinessUtilsTransversal();

            // Act
            var resultado = businessUtilsTransversal.GetGenero(idTipoGenero);

            // Assert
            Assert.True(!string.IsNullOrEmpty(resultado), $"El tipo de Género es: {resultado}");
        }
    }
}
using Business.Transversal;

namespace Test.Business.Transversal
{
    public class GetEstadoTest
    {
        [Fact]
        public void GetEstado()
        {
            // Data Test
            bool estado = true;

            // Arrange
            BusinessUtilsTransversal businessUtilsTransversal  = new BusinessUtilsTransversal();

            // Act
            var resultado = businessUtilsTransversal.GetEstado(estado);

            // Assert
            Assert.True(!string.IsNullOrEmpty(resultado), $"El estado es: {resultado}");
        }
    }
}
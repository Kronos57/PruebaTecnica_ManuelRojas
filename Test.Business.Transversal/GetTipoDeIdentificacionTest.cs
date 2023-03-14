using Business.Transversal;

namespace Test.Business.Transversal
{
    public class GetTipoDeIdentificacionTest
    {
        [Fact]
        public void GetTipoDeIdentificacion()
        {
            // Data Test
            int idTipoIdentificacion = 1;

            // Arrange
            BusinessUtilsTransversal businessUtilsTransversal  = new BusinessUtilsTransversal();

            // Act
            var resultado = businessUtilsTransversal.GetTipoDeIdentificacion(idTipoIdentificacion);

            // Assert
            Assert.True(!string.IsNullOrEmpty(resultado), $"El tipo de Identificación es: {resultado}");
        }
    }
}
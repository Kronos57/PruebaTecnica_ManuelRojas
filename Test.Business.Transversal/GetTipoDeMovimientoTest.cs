using Business.Transversal;

namespace Test.Business.Transversal
{
    public class GetTipoDeMovimientoTest
    {
        [Fact]
        public void GetTipoDeMovimiento()
        {
            // Data Test
            int idTipoMovimiento = 1;

            // Arrange
            BusinessUtilsTransversal businessUtilsTransversal  = new BusinessUtilsTransversal();

            // Act
            var resultado = businessUtilsTransversal.GetTipoDeMovimiento(idTipoMovimiento);

            // Assert
            Assert.True(!string.IsNullOrEmpty(resultado), $"El tipo de Movimiento es: {resultado}");
        }
    }
}
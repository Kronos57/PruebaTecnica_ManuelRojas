using Business.Transversal;
using Transversal.Entities.DTO;

namespace Test.Business.Transversal
{
    public class GetTipoDeCuentaTest
    {
        [Fact]
        public void GetTipoDeCuenta()
        {
            // Data Test
            MovementDTO movementDTO = new MovementDTO
            {
                IdMovimiento = 0,
                IdCuenta = 2,
                IdTipoMovimiento = 1,
                Valor = 150000M,
                FechaMovimiento = DateTime.Now,
                SaldoDisponible = 0,
                Estado = true
            };

            // Arrange
            BusinessUtilsTransversal businessUtilsTransversal  = new BusinessUtilsTransversal();

            // Act
            var resultado = businessUtilsTransversal.GetTipoDeCuenta(movementDTO.IdCuenta);

            // Assert
            Assert.True(!string.IsNullOrEmpty(resultado), $"El tipo de Cuenta es: {resultado}");
        }
    }
}
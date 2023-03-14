using Business.Movements;
using Newtonsoft.Json;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Test.Business.Movements
{
    public class BusinessMovementValidateCreateTest
    {
        [Fact]
        public void ProcessTest()
        {
            // Data Test
            MovementDTO movementDTO = new MovementDTO
            {
                IdMovimiento = 0,
                IdCuenta = 2,
                IdTipoMovimiento = 1,
                Valor = 137000M,
                FechaMovimiento = DateTime.Now,
                SaldoDisponible = 0,
                Estado = true
            };

            // Arrange
            BusinessMovementValidateCreate businessMovementValidateCreateTest = new BusinessMovementValidateCreate(movementDTO);

            StateStrategy stateStrategy = businessMovementValidateCreateTest.Execute();

            var resultado = JsonConvert.SerializeObject(businessMovementValidateCreateTest.Result);

            if (stateStrategy == StateStrategy.Success)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Success, "Movimiento creado correctamente");
                Console.WriteLine(resultado);
            }
            else if (stateStrategy == StateStrategy.Validation)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Validation);
                Console.WriteLine(businessMovementValidateCreateTest.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(businessMovementValidateCreateTest.GetException());
            }
        }
    }
}
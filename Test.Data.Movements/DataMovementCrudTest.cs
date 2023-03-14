using Data.Movements;
using Newtonsoft.Json;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Test.Data.Movements
{
    public class DataMovementCrudTest
    {
        [Fact]
        public void DataMovementCreate()
        {
            // Data Test
            MovementDTO movementDTO = new MovementDTO
            {
                IdMovimiento = 0,
                IdCuenta = 2,
                IdTipoMovimiento = 1,
                Valor = Convert.ToDecimal(150000),
                FechaMovimiento = DateTime.Now,
                SaldoDisponible = 0,
                Estado = true
            };

            // Arrange
            DataMovementCreate dataMovementCreate = new DataMovementCreate(movementDTO);

            // Act
            StateStrategy stateStrategy = dataMovementCreate.Execute();

            var resultado = JsonConvert.SerializeObject(dataMovementCreate.Result);

            if (stateStrategy == StateStrategy.Success)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Success);
                Console.WriteLine(resultado);
            }
            else if (stateStrategy == StateStrategy.Validation)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Validation);
                Console.WriteLine(dataMovementCreate.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataMovementCreate.GetException());
            }
        }

        [Fact]
        public void DataMovementDelete()
        {
            // Data Test
            int idMovimiento = 5;

            // Arrange
            DataMovementDelete dataMovementDelete = new DataMovementDelete(idMovimiento);

            // Act
            StateStrategy stateStrategy = dataMovementDelete.Execute();

            var resultado = JsonConvert.SerializeObject(dataMovementDelete.Result);

            if (stateStrategy == StateStrategy.Success)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Success);
                Console.WriteLine(resultado);
            }
            else if (stateStrategy == StateStrategy.Validation)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Validation);
                Console.WriteLine(dataMovementDelete.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataMovementDelete.GetException());
            }
        }

        [Fact]
        public void DataMovementGetById()
        {
            // Data Test
            int idMovimiento = 5;

            // Arrange
            DataMovementGetById dataMovementGetById = new DataMovementGetById(idMovimiento);

            // Act
            StateStrategy stateStrategy = dataMovementGetById.Execute();

            var resultado = JsonConvert.SerializeObject(dataMovementGetById.Result);

            if (stateStrategy == StateStrategy.Success)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Success);
                Console.WriteLine(resultado);
            }
            else if (stateStrategy == StateStrategy.Validation)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Validation);
                Console.WriteLine(dataMovementGetById.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataMovementGetById.GetException());
            }
        }

        [Fact]
        public void DataMovementGetList()
        {
            // Arrange
            DataMovementGetList dataMovementGetList = new DataMovementGetList();

            // Act
            StateStrategy stateStrategy = dataMovementGetList.Execute();

            var resultado = JsonConvert.SerializeObject(dataMovementGetList.Result);

            if (stateStrategy == StateStrategy.Success)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Success);
                Console.WriteLine(resultado);
            }
            else if (stateStrategy == StateStrategy.Validation)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Validation);
                Console.WriteLine(dataMovementGetList.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataMovementGetList.GetException());
            }
        }

        [Fact]
        public void DataMovementUpdate()
        {
            // Data Test
            MovementDTO movementDTO = new MovementDTO
            {
                IdMovimiento = 0,
                IdCuenta = 2,
                IdTipoMovimiento = 1,
                Valor = Convert.ToDecimal(150000),
                FechaMovimiento = DateTime.Now,
                SaldoDisponible = 0,
                Estado = true
            };

            // Arrange
            DataMovementUpdate dataMovementUpdate = new DataMovementUpdate(movementDTO);

            // Act
            StateStrategy stateStrategy = dataMovementUpdate.Execute();

            var resultado = JsonConvert.SerializeObject(dataMovementUpdate.Result);

            if (stateStrategy == StateStrategy.Success)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Success);
                Console.WriteLine(resultado);
            }
            else if (stateStrategy == StateStrategy.Validation)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Validation);
                Console.WriteLine(dataMovementUpdate.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataMovementUpdate.GetException());
            }
        }
    }
}
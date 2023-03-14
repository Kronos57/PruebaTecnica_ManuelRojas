using Data.Accounts;
using Newtonsoft.Json;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Test.Data.Accounts
{
    public class DataAccountCrudTest
    {
        [Fact]
        public void DataAccountCreate()
        {
            // Data Test
            AccountDTO accountDTO = new AccountDTO
            {
                IdCuenta = 0,
                IdCliente = 1,
                NumeroCuenta = "47873867",
                IdTipoCuenta = 1,
                SaldoInicial = Convert.ToDecimal(7000),
                Estado = true
            };

            // Arrange
            DataAccountCreate dataAccountCreate = new DataAccountCreate(accountDTO);

            // Act
            StateStrategy stateStrategy = dataAccountCreate.Execute();

            var resultado = JsonConvert.SerializeObject(dataAccountCreate.Result);

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
                Console.WriteLine(dataAccountCreate.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataAccountCreate.GetException());
            }
        }

        [Fact]
        public void DataAccountDelete()
        {
            // Data Test
            int idCuenta = 13;

            // Arrange
            DataAccountDelete dataAccountDelete = new DataAccountDelete(idCuenta);

            // Act
            StateStrategy stateStrategy = dataAccountDelete.Execute();

            var resultado = JsonConvert.SerializeObject(dataAccountDelete.Result);

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
                Console.WriteLine(dataAccountDelete.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataAccountDelete.GetException());
            }
        }

        [Fact]
        public void DataAccountGetById()
        {
            // Data Test
            int idCuenta = 13;

            // Arrange
            DataAccountGetById dataAccountGetById = new DataAccountGetById(idCuenta);

            // Act
            StateStrategy stateStrategy = dataAccountGetById.Execute();

            var resultado = JsonConvert.SerializeObject(dataAccountGetById.Result);

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
                Console.WriteLine(dataAccountGetById.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataAccountGetById.GetException());
            }
        }

        [Fact]
        public void DataAccountGetList()
        {
            // Arrange
            DataAccountGetList dataAccountGetList = new DataAccountGetList();

            // Act
            StateStrategy stateStrategy = dataAccountGetList.Execute();

            var resultado = JsonConvert.SerializeObject(dataAccountGetList.Result);

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
                Console.WriteLine(dataAccountGetList.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataAccountGetList.GetException());
            }
        }

        [Fact]
        public void DataAccountUpdate()
        {
            // Data Test
            AccountDTO accountDTO = new AccountDTO
            {
                IdCuenta = 13,
                IdCliente = 1,
                NumeroCuenta = "47873895",
                IdTipoCuenta = 1,
                SaldoInicial = Convert.ToDecimal(8000),
                Estado = true
            };

            // Arrange
            DataAccountUpdate dataAccountUpdate = new DataAccountUpdate(accountDTO);

            // Act
            StateStrategy stateStrategy = dataAccountUpdate.Execute();

            var resultado = JsonConvert.SerializeObject(dataAccountUpdate.Result);

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
                Console.WriteLine(dataAccountUpdate.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataAccountUpdate.GetException());
            }
        }
    }
}
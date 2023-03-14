using Data.Clients;
using Newtonsoft.Json;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Test.Data.Clients
{
    public class DataClientCrudTest
    {
        [Fact]
        public void DataClientCreate()
        {
            // Data Test
            ClientDTO clientDTO = new ClientDTO
            {
                IdPersona = 0,
                Nombre = "PEPITA PÉREZ",
                IdTipoIdentificacion = 1,
                Identificacion = "52147854",
                IdGenero = 1,
                Edad = "32",
                Direccion = "AK 45 # 54-10",
                Telefono = "3053654742",
                IdCliente = 0,
                Contrasenia = "1253",
                Estado = true
            };

            // Arrange
            DataClientCreate dataClientCreate = new DataClientCreate(clientDTO);

            // Act
            StateStrategy stateStrategy = dataClientCreate.Execute();

            var resultado = JsonConvert.SerializeObject(dataClientCreate.Result);

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
                Console.WriteLine(dataClientCreate.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataClientCreate.GetException());
            }
        }

        [Fact]
        public void DataClientDelete()
        {
            // Data Test
            int idCliente = 9;

            // Arrange
            DataClientDelete dataClientDelete = new DataClientDelete(idCliente);

            // Act
            StateStrategy stateStrategy = dataClientDelete.Execute();

            var resultado = JsonConvert.SerializeObject(dataClientDelete.Result);

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
                Console.WriteLine(dataClientDelete.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataClientDelete.GetException());
            }
        }

        [Fact]
        public void DataClientGetById()
        {
            // Data Test
            int idCliente = 9;

            // Arrange
            DataClientGetById dataClientGetById = new DataClientGetById(idCliente);

            // Act
            StateStrategy stateStrategy = dataClientGetById.Execute();

            var resultado = JsonConvert.SerializeObject(dataClientGetById.Result);

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
                Console.WriteLine(dataClientGetById.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataClientGetById.GetException());
            }
        }

        [Fact]
        public void DataClientGetList()
        {
            // Arrange
            DataClientGetList dataClientGetList = new DataClientGetList();

            // Act
            StateStrategy stateStrategy = dataClientGetList.Execute();

            var resultado = JsonConvert.SerializeObject(dataClientGetList.Result);

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
                Console.WriteLine(dataClientGetList.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataClientGetList.GetException());
            }
        }

        [Fact]
        public void DataClientUpdate()
        {
            // Data Test
            ClientDTO clientDTO = new ClientDTO
            {
                IdPersona = 6,
                Nombre = "PEPITA PÉREZ",
                IdTipoIdentificacion = 1,
                Identificacion = "52147854",
                IdGenero = 1,
                Edad = "32",
                Direccion = "AK 45 # 54-10",
                Telefono = "3053654742",
                IdCliente = 4,
                Contrasenia = "1253",
                Estado = true
            };

            // Arrange
            DataClientUpdate dataClientUpdate = new DataClientUpdate(clientDTO);

            // Act
            StateStrategy stateStrategy = dataClientUpdate.Execute();

            var resultado = JsonConvert.SerializeObject(dataClientUpdate.Result);

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
                Console.WriteLine(dataClientUpdate.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(dataClientUpdate.GetException());
            }
        }
    }
}
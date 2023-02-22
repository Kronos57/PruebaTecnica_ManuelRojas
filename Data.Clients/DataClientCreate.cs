using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Clients
{
    public class DataClientCreate : DataStrategy
    {
        private ClientDTO clientDTO;
        public DataClientCreate(ClientDTO clientDTO)
        {
            this.clientDTO = clientDTO;
        }

        protected override void Process()
        {
            using (var context = new ApiRestDbManuelRojasContext())
            {
                ClientRepository clientRepository = new ClientRepository(context);
                PersonRepository personRepository = new PersonRepository(context);

                Persona entityPersona = new Persona
                {
                    IdPersona = clientDTO.IdPersona,
                    Nombre = clientDTO.Nombre,
                    IdTipoIdentificacion = clientDTO.IdTipoIdentificacion,
                    Identificacion = clientDTO.Identificacion != null ? clientDTO.Identificacion : VALIDATION_MESSAGES.DEFAULT_VALUE,
                    IdGenero = clientDTO.IdGenero,
                    Edad = clientDTO.Edad,
                    Direccion = clientDTO.Direccion,
                    Telefono = clientDTO.Telefono
                };

                personRepository.Add(entityPersona);
                context.SaveChanges();

                int newIdPerson = entityPersona.IdPersona;

                Cliente entityCliente = new Cliente
                {
                    IdCliente = clientDTO.IdCliente,
                    IdPersona= newIdPerson,
                    Contrasenia = clientDTO.Contrasenia != null ? clientDTO.Contrasenia : VALIDATION_MESSAGES.DEFAULT_VALUE,
                    Estado = clientDTO.Estado,
                };

                clientRepository.Add(entityCliente);
                SetResponseResult(CLIENT_MESSAGES.CLIENTE_CREADO);
            }
        }
    }
}

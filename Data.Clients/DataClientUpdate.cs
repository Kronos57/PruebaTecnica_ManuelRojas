using Data.EntityFramework.Entities;
using Repository;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Clients
{
    public class DataClientUpdate : DataStrategy
    {
        private ClientDTO clientDTO;
        public DataClientUpdate(ClientDTO clientDTO)
        {
            this.clientDTO = clientDTO;
        }

        protected override void Process()
        {
            using (var context = new ApiRestDbManuelRojasContext())
            {
                ClientRepository clientRepository = new ClientRepository(context);
                PersonRepository personRepository = new PersonRepository(context);

                Cliente entityCliente = clientRepository.GetById(clientDTO.IdCliente);             

                if (entityCliente != null)
                {
                    //Tabla Cliente
                    entityCliente.IdCliente = clientDTO.IdCliente;
                    entityCliente.Contrasenia = clientDTO.Contrasenia != null? clientDTO.Contrasenia : entityCliente.Contrasenia;
                    entityCliente.Estado = clientDTO.Estado;

                    //Tabla Persona
                    Persona entityPersona = personRepository.GetById(entityCliente.IdPersona);

                    if (entityPersona != null) 
                    {
                        entityPersona.Nombre = clientDTO.Nombre;
                        entityPersona.IdTipoIdentificacion = clientDTO.IdTipoIdentificacion;
                        entityPersona.Identificacion = clientDTO.Identificacion != null ? clientDTO.Identificacion: entityPersona.Identificacion;
                        entityPersona.IdGenero = clientDTO.IdGenero;
                        entityPersona.Edad = clientDTO.Edad;
                        entityPersona.Direccion = clientDTO.Direccion;
                        entityPersona.Telefono = clientDTO.Telefono;

                        personRepository.Update(entityPersona);
                    }
                    else
                    {
                        SetException(EXCEPTION_MESSAGES.PERSONA_NO_EXISTE);
                        return;
                    }

                    clientRepository.Update(entityCliente);              
                    SetResponseResult(CLIENT_MESSAGES.CLIENTE_ACTUALIZADO);
                }
                else
                {
                    SetException(EXCEPTION_MESSAGES.CLIENTE_NO_EXISTE);
                }
            }
        }
    }
}

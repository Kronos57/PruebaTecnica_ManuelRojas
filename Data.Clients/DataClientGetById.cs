using Business.Transversal;
using Data.EntityFramework.Entities;
using Services;
using Transversal.Entities.DTO;
using Transversal.Strategy;
using static Transversal.Entities.ConstantMessages;

namespace Data.Clients
{
    public class DataClientGetById : DataStrategy
    {
        private int id;
        public DataClientGetById(int id)
        {
            this.id = id;
        }

        protected override void Process()
        {
            BusinessUtilsTransversal utils = new BusinessUtilsTransversal();

            using (var context = new ApiRestDbManuelRojasContext())
            {
                ClientRepositoryService clientRepository = new ClientRepositoryService(context);
                PersonRepositoryService personRepository = new PersonRepositoryService(context);

                Cliente entityClient = clientRepository.GetById(id);

                if (entityClient != null)
                {
                    Persona entityPersona = personRepository.GetById(entityClient.IdPersona);

                    SetResult(new ClientSearchDTO(entityClient.IdCliente, entityClient.Contrasenia, utils.GetEstado(entityClient.Estado),
                        entityPersona.IdPersona, entityPersona.Nombre, utils.GetTipoDeIdentificacion(entityPersona.IdTipoIdentificacion),
                        entityPersona.Identificacion, utils.GetGenero(entityPersona.IdGenero), entityPersona.Edad, entityPersona.Direccion,
                        entityPersona.Telefono));
                }
                else
                {
                    SetException(EXCEPTION_MESSAGES.CLIENTE_NO_EXISTE);
                }
            }
        }
    }
}

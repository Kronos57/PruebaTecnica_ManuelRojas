﻿using Business.Transversal;
using Data.EntityFramework.Entities;
using Services;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Data.Clients
{
    public class DataClientGetList : DataStrategy
    {
        public DataClientGetList() { }

        protected override void Process()
        {
            List<ClientSearchDTO> clients = new List<ClientSearchDTO>();
            BusinessUtilsTransversal utils = new BusinessUtilsTransversal();

            using (var context = new ApiRestDbManuelRojasContext())
            {
                ClientRepositoryService clientRepository = new ClientRepositoryService(context);
                PersonRepositoryService personRepository = new PersonRepositoryService(context);

                IEnumerable<Cliente> entityClients = clientRepository.GetAll();

                foreach (Cliente entityClient in entityClients)
                {
                    Persona entityPersona = personRepository.GetById(entityClient.IdPersona);

                    clients.Add(new ClientSearchDTO(entityClient.IdCliente, entityClient.Contrasenia, utils.GetEstado(entityClient.Estado), 
                        entityPersona.IdPersona, entityPersona.Nombre, utils.GetTipoDeIdentificacion(entityPersona.IdTipoIdentificacion), 
                        entityPersona.Identificacion, utils.GetGenero(entityPersona.IdGenero), entityPersona.Edad, entityPersona.Direccion, 
                        entityPersona.Telefono));
                }
            }

            SetResult(clients);
        }
    }
}

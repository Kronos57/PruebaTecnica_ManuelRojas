using Data.Clients;
using Microsoft.AspNetCore.Mvc;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<ClientSearchDTO>> GetAll()
        {
            try
            {
                DataClientGetList dataClientGetList = new DataClientGetList();

                if (dataClientGetList.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Consultando todos los Clientes");
                    return Ok(dataClientGetList.Result);
                }
                else
                {
                    return BadRequest(dataClientGetList.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al consultar los Clientes: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }           
        }

        [HttpGet("GetById")]
        public ActionResult<IEnumerable<ClientSearchDTO>> GetById(int id)
        {
            try
            {
                DataClientGetById dataClientGetById = new DataClientGetById(id);

                if (dataClientGetById.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Consultando el Cliente con Id: " + id);
                    return Ok(dataClientGetById.Result);
                }
                else
                {
                    return BadRequest(dataClientGetById.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al consultar el Cliente con Id: " + id + ". Error: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(ClientDTO clientDTO)
        {
            try
            {
                DataClientCreate dataClientCreate = new DataClientCreate(clientDTO);

                if (dataClientCreate.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Creando el Cliente con Id: " + clientDTO.IdCliente);
                    return Ok(dataClientCreate.Result);
                }
                else
                {                 
                    return BadRequest(dataClientCreate.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear el Cliente: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(ClientDTO clientDTO)
        {
            try
            {
                DataClientUpdate dataClientUpdate = new DataClientUpdate(clientDTO);

                if (dataClientUpdate.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Actualizando el Cliente con Id: " + clientDTO.IdCliente);
                    return Ok(dataClientUpdate.Result);
                }
                else
                {
                    return BadRequest(dataClientUpdate.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al actualizar el Cliente con Id: " + clientDTO.IdCliente + ". Error: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }           
        }

        [HttpDelete("DeleteById")]
        public ActionResult Delete(int id)
        {
            try
            {
                DataClientDelete dataClientDelete = new DataClientDelete(id);

                if (dataClientDelete.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Eliminando el Cliente con Id " + id);
                    return Ok(dataClientDelete.Result);
                }
                else
                {
                    return BadRequest(dataClientDelete.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al eliminar el Cliente con Id : " + id + ". Error: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }           
        }
    }
}

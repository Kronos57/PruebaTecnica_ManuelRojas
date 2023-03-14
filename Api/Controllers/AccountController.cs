using Data.Accounts;
using Microsoft.AspNetCore.Mvc;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<AccountSearchDTO>> GetAll()
        {
            try
            {
                DataAccountGetList dataAccountGetList = new DataAccountGetList();

                if (dataAccountGetList.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Consultando todas las Cuentas");
                    return Ok(dataAccountGetList.Result);
                }
                else
                {              
                    return BadRequest(dataAccountGetList.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al consultar las Cuentas: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);      
            }        
        }

        [HttpGet("GetById")]
        public ActionResult<IEnumerable<AccountSearchDTO>> GetById(int id)
        {
            try
            {
                DataAccountGetById dataAccountGetById = new DataAccountGetById(id);

                if (dataAccountGetById.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Consultando la Cuenta con Id: " + id);
                    return Ok(dataAccountGetById.Result);
                }
                else
                {
                    return BadRequest(dataAccountGetById.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al consultar la Cuenta con Id: " + id + ". Error: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }    
        }

        [HttpPost("Create")]
        public ActionResult Create(AccountDTO accountDTO)
        {
            try
            {
                DataAccountCreate dataAccountCreate = new DataAccountCreate(accountDTO);

                if (dataAccountCreate.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Creando la Cuenta No." + accountDTO.NumeroCuenta);
                    return Ok(dataAccountCreate.Result);
                }
                else
                {
                    return BadRequest(dataAccountCreate.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear la Cuenta: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }        
        }

        [HttpPut("Update")]
        public ActionResult Update(AccountDTO accountDTO)
        {
            try
            {
                DataAccountUpdate dataAccountUpdate = new DataAccountUpdate(accountDTO);

                if (dataAccountUpdate.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Actualizando la Cuenta No." + accountDTO.NumeroCuenta);
                    return Ok(dataAccountUpdate.Result);
                }
                else
                {
                    return BadRequest(dataAccountUpdate.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al actualizar la Cuenta No.: " + accountDTO.NumeroCuenta + ". Error: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }        
        }

        [HttpDelete("DeleteById")]
        public ActionResult Delete(int id)
        {
            try
            {
                DataAccountDelete dataAccountDelete = new DataAccountDelete(id);

                if (dataAccountDelete.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Eliminando la Cuenta con Id " + id);
                    return Ok(dataAccountDelete.Result);
                }
                else
                {
                    return BadRequest(dataAccountDelete.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al eliminar la Cuenta con Id : " + id + ". Error: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }          
        }
    }
}

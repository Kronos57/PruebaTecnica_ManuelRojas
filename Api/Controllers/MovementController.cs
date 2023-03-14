using Business.Movements;
using Data.Movements;
using Microsoft.AspNetCore.Mvc;
using Transversal.Entities.DTO;
using Transversal.Strategy;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly ILogger<MovementController> _logger;

        public MovementController(ILogger<MovementController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<MovementSearchDTO>> GetAll()
        {
            try
            {
                DataMovementGetList dataMovementGetList = new DataMovementGetList();

                if (dataMovementGetList.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Consultando todos los Movimientos");
                    return Ok(dataMovementGetList.Result);
                }
                else
                {
                    return BadRequest(dataMovementGetList.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al consultar los Movimientos: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }           
        }

        [HttpGet("GetById")]
        public ActionResult<IEnumerable<MovementSearchDTO>> GetById(int id)
        {
            try
            {
                DataMovementGetById dataMovementGetById = new DataMovementGetById(id);

                if (dataMovementGetById.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Consultando el Movimiento con Id: " + id);
                    return Ok(dataMovementGetById.Result);
                }
                else
                {
                    return BadRequest(dataMovementGetById.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al consultar el Movimiento con Id: " + id + ". Error: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }            
        }

        [HttpPost("Create")]
        public ActionResult Create(MovementDTO movementDTO)
        {
            try
            {
                BusinessMovementValidateCreate businessCreditMovement = new BusinessMovementValidateCreate(movementDTO);

                if (businessCreditMovement.Execute() == StateStrategy.Success)
                {
                    _logger.LogInformation("Creando el Movimiento para la cuenta con Id: " + movementDTO.IdCuenta);
                    return Ok(businessCreditMovement.Result);
                }
                else
                {
                    return BadRequest(businessCreditMovement.GetException());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear el Movimiento: " + ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }         
        }       
    }
}

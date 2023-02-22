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
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<MovementSearchDTO>> GetAll()
        {
            DataMovementGetList dataMovementGetList = new DataMovementGetList();

            if (dataMovementGetList.Execute() == StateStrategy.Success)
            {
                return Ok(dataMovementGetList.Result);
            }
            else
            {
                return BadRequest(dataMovementGetList.GetException());
            }
        }

        [HttpGet("GetById")]
        public ActionResult<IEnumerable<MovementSearchDTO>> GetById(int id)
        {
            DataMovementGetById dataMovementGetById = new DataMovementGetById(id);

            if (dataMovementGetById.Execute() == StateStrategy.Success)
            {
                return Ok(dataMovementGetById.Result);
            }
            else
            {
                return BadRequest(dataMovementGetById.GetException());
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(MovementDTO movementDTO)
        {
            BusinessMovementValidateCreate businessCreditMovement = new BusinessMovementValidateCreate(movementDTO);

            if (businessCreditMovement.Execute() == StateStrategy.Success)
            {
                return Ok(businessCreditMovement.Result);
            }
            else
            {
                return BadRequest(businessCreditMovement.GetException());
            }
        }       
    }
}

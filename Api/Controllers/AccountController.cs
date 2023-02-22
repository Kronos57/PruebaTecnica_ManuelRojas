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
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<AccountSearchDTO>> GetAll()
        {
            DataAccountGetList dataAccountGetList = new DataAccountGetList();

            if (dataAccountGetList.Execute() == StateStrategy.Success)
            {
                return Ok(dataAccountGetList.Result);
            }
            else
            {
                return BadRequest(dataAccountGetList.GetException());
            }
        }

        [HttpGet("GetById")]
        public ActionResult<IEnumerable<AccountSearchDTO>> GetById(int id)
        {
            DataAccountGetById dataAccountGetById = new DataAccountGetById(id);

            if (dataAccountGetById.Execute() == StateStrategy.Success)
            {
                return Ok(dataAccountGetById.Result);
            }
            else
            {
                return BadRequest(dataAccountGetById.GetException());
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(AccountDTO accountDTO)
        {
            DataAccountCreate dataAccountCreate = new DataAccountCreate(accountDTO);

            if (dataAccountCreate.Execute() == StateStrategy.Success)
            {
                return Ok(dataAccountCreate.Result);
            }
            else
            {
                return BadRequest(dataAccountCreate.GetException());
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(AccountDTO accountDTO)
        {
            DataAccountUpdate dataAccountUpdate = new DataAccountUpdate(accountDTO);

            if (dataAccountUpdate.Execute() == StateStrategy.Success)
            {
                return Ok(dataAccountUpdate.Result);
            }
            else
            {
                return BadRequest(dataAccountUpdate.GetException());
            }
        }

        [HttpDelete("DeleteById")]
        public ActionResult Delete(int id)
        {
            DataAccountDelete dataAccountDelete = new DataAccountDelete(id);

            if (dataAccountDelete.Execute() == StateStrategy.Success)
            {
                return Ok(dataAccountDelete.Result);
            }
            else
            {
                return BadRequest(dataAccountDelete.GetException());
            }
        }
    }
}

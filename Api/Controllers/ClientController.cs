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
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<ClientSearchDTO>> GetAll()
        {
            DataClientGetList dataClientGetList = new DataClientGetList();

            if (dataClientGetList.Execute() == StateStrategy.Success)
            {
                return Ok(dataClientGetList.Result);
            }
            else
            {
                return BadRequest(dataClientGetList.GetException());
            }
        }

        [HttpGet("GetById")]
        public ActionResult<IEnumerable<ClientSearchDTO>> GetById(int id)
        {
            DataClientGetById dataClientGetById = new DataClientGetById(id);

            if (dataClientGetById.Execute() == StateStrategy.Success)
            {
                return Ok(dataClientGetById.Result);
            }
            else
            {
                return BadRequest(dataClientGetById.GetException());
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(ClientDTO clientDTO)
        {
            DataClientCreate dataClientCreate = new DataClientCreate(clientDTO);

            if (dataClientCreate.Execute() == StateStrategy.Success)
            {
                return Ok(dataClientCreate.Result);
            }
            else
            {
                return BadRequest(dataClientCreate.GetException());
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(ClientDTO clientDTO)
        {
            DataClientUpdate dataClientUpdate = new DataClientUpdate(clientDTO);

            if (dataClientUpdate.Execute() == StateStrategy.Success)
            {
                return Ok(dataClientUpdate.Result);
            }
            else
            {
                return BadRequest(dataClientUpdate.GetException());
            }
        }

        [HttpDelete("DeleteById")]
        public ActionResult Delete(int id)
        {
            DataClientDelete dataClientDelete = new DataClientDelete(id);

            if (dataClientDelete.Execute() == StateStrategy.Success)
            {
                return Ok(dataClientDelete.Result);
            }
            else
            {
                return BadRequest(dataClientDelete.GetException());
            }
        }
    }
}

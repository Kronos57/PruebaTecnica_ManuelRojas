using Data.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Data.Clients;
using Data.Accounts;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuenta>>> GetCuentas()
        {          
            DataAccountGetList dataAccountGetList = new DataAccountGetList();

            if (true)
            {

            }

            //var cuentas = await _accountRepository.GetAllAccountsAsync();
            //return Ok(cuentas);
        }


    }
}

using Business.Reports;
using Microsoft.AspNetCore.Mvc;
using Transversal.Entities.DTO;
using Transversal.Entities.Reports.AccountStatus;
using Transversal.Strategy;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        [HttpPost("GetReportAccountStatus")]
        public ActionResult<IEnumerable<AccountSearchDTO>> GetReportAccountStatus(AccountStatusRequest accountStatusRequest)
        {
            BusinessReportAccountStatus businessReportAccountStatus = new BusinessReportAccountStatus(accountStatusRequest); 

            if (businessReportAccountStatus.Execute() == StateStrategy.Success)
            {
                return Ok(businessReportAccountStatus.Result);
            }
            else
            {
                return BadRequest(businessReportAccountStatus.GetException());
            }
        }
    }
}

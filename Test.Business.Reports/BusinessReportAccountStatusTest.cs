using Business.Reports;
using Newtonsoft.Json;
using Transversal.Entities.Reports.AccountStatus;
using Transversal.Strategy;

namespace Test.Business.Reports
{
    public class BusinessReportAccountStatusTest
    {
        [Fact]
        public void ProcessTest()
        {
            // Data Test
            AccountStatusRequest accountStatusRequest = new AccountStatusRequest
            {
                IdCliente = 2,
                FechaInicial = Convert.ToDateTime("2023-02-01"),
                FechaFinal = Convert.ToDateTime("2023-02-28")
            };

            // Arrange
            BusinessReportAccountStatus businessReportAccountStatus = new BusinessReportAccountStatus(accountStatusRequest);

            StateStrategy stateStrategy = businessReportAccountStatus.Execute();

            var resultado = JsonConvert.SerializeObject(businessReportAccountStatus.Result);

            if (stateStrategy == StateStrategy.Success)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Success);
                Console.WriteLine(resultado);
            }
            else if (stateStrategy == StateStrategy.Validation)
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Validation);
                Console.WriteLine(businessReportAccountStatus.GetValidation());
            }
            else
            {
                // Assert
                Assert.True(stateStrategy == StateStrategy.Exception);
                Console.WriteLine(businessReportAccountStatus.GetException());
            }          
        }
    }
}
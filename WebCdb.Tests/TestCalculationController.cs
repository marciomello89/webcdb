using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using WebCdb.Controllers;
using WebCdb.Domain.IServices;
using WebCdb.Models.Request;
using WebCdb.Models.Response;
using WebCdb.Services;

namespace WebCdb.Tests
{
    [TestClass]
    public class TestCalculationController
    {
        [TestMethod]
        public void Calculate_ShouldReturnCorrectValueForSixMonths()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                Value = 100.00M,
                Period = 2
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.RawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectValueForTwelveMonths()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                Value = 100.00M,
                Period = 12
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.RawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectValueForTwentyFourMonths()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                Value = 100.00M,
                Period = 24
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.RawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectValueForMoreThanTwentyFourMonths()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                Value = 100.00M,
                Period = 36
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.RawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnBadRequest()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                Value = 100.00M,
                Period = 1
            };

            var controller = new CalculationController(calculationService);
            controller.ModelState.AddModelError("BadRequest", "BadRequest error test!");
            var result = (BadRequestErrorMessageResult)controller.Calculate(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("Value should be a positive number and period should be an integer greater than 1!", result.Message);
        }
    }
}

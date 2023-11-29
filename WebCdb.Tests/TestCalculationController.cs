using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                value = 100.00M,
                period = 2
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.rawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectValueForTwelveMonths()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                value = 100.00M,
                period = 12
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.rawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectValueForTwentyFourMonths()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                value = 100.00M,
                period = 24
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.rawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnCorrectValueForMoreThanTwentyFourMonths()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                value = 100.00M,
                period = 36
            };

            var controller = new CalculationController(calculationService);

            var result = controller.Calculate(request) as OkNegotiatedContentResult<CdbResponse>;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.rawValue > 0);
        }

        [TestMethod]
        public void Calculate_ShouldReturnBadRequest()
        {
            ICalculationService calculationService = new CalculationService();
            var request = new CdbRequest()
            {
                value = 100.00M,
                period = 1
            };

            var controller = new CalculationController(calculationService);
            controller.ModelState.AddModelError("BadRequest", "BadRequest error test!");
            var result = (BadRequestErrorMessageResult)controller.Calculate(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Message, "Value should be a positive number and period should be an integer greater than 1!");
        }
    }
}

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
        public void GetAllProducts_ShouldReturnCorrectValueForSixMonths()
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
        public void GetAllProducts_ShouldReturnCorrectValueForTwelveMonths()
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
        public void GetAllProducts_ShouldReturnCorrectValueForTwentyFourMonths()
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
        public void GetAllProducts_ShouldReturnCorrectValueForMoreThanTwentyFourMonths()
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
    }
}

using System;
using System.Web.Http;
using WebCdb.Domain.IServices;
using WebCdb.Models.Request;

namespace WebCdb.Controllers
{
    [RoutePrefix("api/calculation")]
    public class CalculationController : ApiController
    {
        private readonly ICalculationService _calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpPost]
        [Route("calculate")]
        public IHttpActionResult Calculate([FromBody] CdbRequest request)
        {
            try
            {
                return Ok(_calculationService.CalculateCdb(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
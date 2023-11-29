using System;
using System.Web.Http;
using System.Web.Http.Description;
using WebCdb.Domain.IServices;
using WebCdb.Models.Request;
using WebCdb.Models.Response;

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

        /// <summary>
        /// Calculate CDB
        /// </summary>
        /// <param name="request">CDB request model</param>
        /// <remarks>Calculate CDB based off of a value and a period</remarks>
        /// <response code="200">Request was successful</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [Route("calculate")]
        [ResponseType(typeof(CdbResponse))]
        public IHttpActionResult Calculate([FromBody] CdbRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(_calculationService.CalculateCdb(request));
                else
                    return BadRequest("Value should be a positive number and period should be an integer greater than 1!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
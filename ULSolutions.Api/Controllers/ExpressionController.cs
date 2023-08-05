using Microsoft.AspNetCore.Mvc;
using System.Net;
using ULSolutions.Business.Helpers;

namespace ULSolutions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpressionController : ControllerBase
    {
        public ExpressionController(IExpressionHelper expressionHelper)
        {
            ExpressionHelper = expressionHelper;
        }

        public IExpressionHelper ExpressionHelper { get; }

        /// <summary>
        /// Evaluates the sum of a string expression 
        /// </summary>
        /// <param name="expression">The expression being evaluated</param>
        /// <returns>An IAction result</returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult Evaluate([FromBody] string expression)
        {
            try
            {
                var result = ExpressionHelper.Evaluate(expression);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.InnerException?.Message);
                else if (ex is DivideByZeroException)
                    return BadRequest("Unable to divide by zero");
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}

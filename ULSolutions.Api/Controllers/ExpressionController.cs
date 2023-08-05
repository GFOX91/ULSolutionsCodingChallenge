using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Evaluate([FromBody] string expression)
        {
            try
            {
                var result = ExpressionHelper.Evaluate(expression);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }



            return Ok();
        }
    }
}

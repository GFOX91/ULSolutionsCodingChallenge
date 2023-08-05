﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
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
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ULSolutions.Api.Controllers;
using ULSolutions.Business.Helpers;

namespace ULSolutions.Test.Api
{
   
    public class ExpressionControllerTests
    {
        #region Setup

        private readonly ExpressionController controller;

        internal Mock<IExpressionHelper> ExpressionHelper { get; }

        public ExpressionControllerTests()
        {
            ExpressionHelper = new Mock<IExpressionHelper>(MockBehavior.Strict);

            controller = new ExpressionController(ExpressionHelper.Object);
        }

        #endregion Setup

        #region Evaluate

        [Fact]
        private void Evaluate_ReturnsBadRequest_WhenArguementExceptionThrown()
        {
            // arrange
            string expression = "";

            ExpressionHelper.Setup(x => x.Evaluate(expression)).Throws<ArgumentException>();

            // act
            var result = controller.Evaluate(expression) as ObjectResult;

            // assert
            result?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            ExpressionHelper.Verify(x => x.Evaluate(expression), Times.Once);
        }

        #endregion Evaluate
    }
}

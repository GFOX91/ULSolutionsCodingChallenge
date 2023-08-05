using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULSolutions.Business.Helpers;

namespace ULSolutions.Test.Business
{
    public class ExpressionTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Evaluate_ThrowsException_WhenExpressionIsNullOrWhiteSpace(string expression)
        {
            // Arrange
            var sut = new ExpressionHelper();

            // Act
            var result = () => sut.Evaluate(expression);

            // Assert
            result.Should().Throw<ArgumentException>().WithMessage("expression cannot be null or empty");
        }
    }
}

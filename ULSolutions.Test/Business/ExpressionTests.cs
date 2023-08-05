using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULSolutions.Business.Helpers;

namespace ULSolutions.Test.Business
{
    /// <summary>
    /// To test and cover the methods in the expression helper class
    /// </summary>
    public class ExpressionHelperTests
    {
        #region SpltIntoNumbersAndOperators

        [Fact]
        public void SplitIntoNumbersAndOperators_ReturnsListOfNumbersAndOperators()
        {
            // Arrange
            var sut = new ExpressionHelper();

            var expression = "4+5*2";

            var expectedResult = new List<string>()
            {
                "4",
                "+",
                "5",
                "*",
                "2",
            };

            // Act
            var result = sut.SplitIntoNumbersAndOperators(expression);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        #endregion SpltIntoNumbersAndOperators

        #region Evaluate

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
            result.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("1++2")]
        [InlineData("+3+2 ")]
        [InlineData("3/2++")]
        public void Evaluate_ThrowsException_WhenExpressionIsNotInCorrectFormat(string expression)
        {
            // Arrange
            var sut = new ExpressionHelper();

            // Act
            var result = () => sut.Evaluate(expression);

            // Assert
            result.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("4+5*2", 14)]
        [InlineData("4+5/2", 6.5)]
        [InlineData("4+5/2-1", 5.5)]
        [InlineData("4+10/2-1", 8)]
        public void Evaluate_ReturnsCalculatedResult_WhenOk(string expression, double actualResult)
        {
            // Arrange
            var sut = new ExpressionHelper();

            // Act
            var expectedResult = sut.Evaluate(expression);

            // Assert
            expectedResult.Should().Be(actualResult);
        }

        #endregion Evaluate


    }
}

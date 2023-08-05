using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ULSolutions.Business.Helpers
{
    public class ExpressionHelper
    {
        /// <summary>
        /// Evaluates the sum of a string expression
        /// </summary>
        /// <param name="expression">The string expression be evaluated</param>
        /// <returns>The result of the evaluated expression as a double</returns>
        public double Evaluate(string expression)
        {
            expression = Validate(expression);
            var numbersAndOperators = SplitIntoNumbersAndOperators(expression);
            return CalculateByOperatorPrecedence(numbersAndOperators);
        }

        private string Validate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) throw new ArgumentException("expression cannot be null or empty");

            expression = String.Concat(expression.Where(c => !Char.IsWhiteSpace(c)));

            Regex expectedFormat = new Regex(@"^([0-9]+[-+*\/])+[0-9]+$");
            if (expectedFormat.IsMatch(expression) == false) throw new ArgumentException("Expression is in invalid format");

            return expression;
        }

        public List<string> SplitIntoNumbersAndOperators(string expression)
        {
            Regex regex = new Regex(@"([0-9]+|[-+\/*]){1}");
            return regex.Matches(expression).Select(match => match.Value).ToList();
        }

        public double CalculateByOperatorPrecedence(List<string>numbersAndOperators)
        {
            double result = 0;
            List<string> OperatorsInOrderOfBodmas = new List<string>() { "/", "*", "+", "-" };

            while (numbersAndOperators.Count() > 1)
            {
                foreach (var @operator in OperatorsInOrderOfBodmas)
                {
                    int operatorIndex = numbersAndOperators.IndexOf(@operator);

                    if (operatorIndex > 0)
                    {
                        string currentOperator = numbersAndOperators[operatorIndex];
                        double leftNumber = double.Parse(numbersAndOperators[operatorIndex - 1]);
                        double rightNumber = double.Parse(numbersAndOperators[operatorIndex + 1]);

                        result = CalculateNextResult(currentOperator, leftNumber, rightNumber);

                        ReplaceSumCalculatedWithCurrentResult(operatorIndex, result, numbersAndOperators);
                    }
                }
            }

            return result;
        }

        public double CalculateNextResult(string @operator, double leftNumber, double rightNumber)
        {
            if (@operator == "/")
                return leftNumber / rightNumber;
            else if (@operator == "*")
                return leftNumber * rightNumber;
            else if (@operator == "+")
                return leftNumber + rightNumber;
            else
                return leftNumber - rightNumber;
        }

        private void ReplaceSumCalculatedWithCurrentResult(int operatorIndex, double result, List<string> numbersAndOperators)
        {
            numbersAndOperators.RemoveAt(operatorIndex);
            numbersAndOperators.Insert(operatorIndex, result.ToString());
            numbersAndOperators.RemoveAt(operatorIndex + 1);
            numbersAndOperators.RemoveAt(operatorIndex - 1);
        }


    }
}

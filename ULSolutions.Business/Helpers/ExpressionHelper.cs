using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ULSolutions.Business.Helpers
{
    public class ExpressionHelper
    {
        public double Evaluate(string expression)
        {
            // 1. Perform some bounds checking - Validate string provided is not null, remove any spaces and ensure string is in expected form, return relevant exceptions if any checking fails
           expression = Validate(expression);

            // 3. Find the value of the first number in the expression, will be used as initial sum in calculation
            int firstNumber = int.Parse(expression.Substring(0, 1));

            double sum = firstNumber;

            for (int i = 1; i<expression.Length; i += 2)
            {
                string nextOperator = expression.Substring(i, 1);
                int nextNumber = int.Parse(expression.Substring(++i, 1));
            }

            // 4. Iterate through remaining characters in the expression and update the existing sum value based on the next operator and number
            // 5. return the final sum

            return 0;
        }

        private string Validate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) throw new ArgumentException("expression cannot be null or empty");

            expression = String.Concat(expression.Where(c => !Char.IsWhiteSpace(c)));

            Regex expectedFormat = new Regex(@"^([0-9]+[-+*\/])+[0-9]+$");
            if (expectedFormat.IsMatch(expression) == false) throw new ArgumentException("Expression is in invalid format");

            return expression;
        }
    }
}

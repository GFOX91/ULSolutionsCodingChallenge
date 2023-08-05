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

            // 2. split expression into list of factors
            var factors = SplitIntoNumbersAndOperators(expression);

            // 3. iterate in order od DMAS and perform calulation
            List<string> dmas = new List<string>() { "/", "*", "+", "-" };

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

        public List<string> SplitIntoNumbersAndOperators(string expression)
        {
            Regex regex = new Regex(@"(\d+|[-+\/*]){1}");
            return regex.Matches(expression).Select(match => match.Value).ToList();
        }
    }
}

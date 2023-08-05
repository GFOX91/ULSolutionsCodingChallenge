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
        public double Evaluate(string expression)
        {
            // 1. Perform some bounds checking - Validate string provided is not null, remove any spaces and ensure string is in expected form, return relevant exceptions if any checking fails
           expression = Validate(expression);

            // 2. split expression into list of factors
            var numbersAndOperators = SplitIntoNumbersAndOperators(expression);

            // 3. iterate in order of DMAS and perform calulation using left number, operator and, right number
            List<string> dmas = new List<string>() { "/", "*", "+", "-" };

            double result = 0;

            while (numbersAndOperators.Count() > 1) 
            {
                foreach (var dmasOperator in dmas) 
                {
                    int operatorIndex = numbersAndOperators.IndexOf(dmasOperator);

                    if (operatorIndex > 0)
                    {
                        double leftNumber = double.Parse(numbersAndOperators[operatorIndex - 1]);
                        double rightNumber = double.Parse(numbersAndOperators[operatorIndex + 1]);
                        string currentOperator = numbersAndOperators[operatorIndex];

                        if (currentOperator == "/")
                            result = leftNumber / rightNumber;
                        else if (currentOperator == "*")
                            result = leftNumber * rightNumber;
                        else if (currentOperator == "+")
                            result = leftNumber + rightNumber;
                        else if (currentOperator == "-")
                            result = leftNumber - rightNumber;

                        numbersAndOperators.RemoveAt(operatorIndex);
                        numbersAndOperators.Insert(operatorIndex, result.ToString());
                        numbersAndOperators.RemoveAt(operatorIndex + 1);
                        numbersAndOperators.RemoveAt(operatorIndex - 1);

                    }
                }   
            }



            return result;
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

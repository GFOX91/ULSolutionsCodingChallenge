using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULSolutions.Business.Helpers
{
    public class ExpressionHelper
    {
        public double Evaluate(string expression)
        {
            // 1. Perform some bounds checking - Validate string provided is not null and is in expected form, return relevant exceptions if any checking fails
            if (string.IsNullOrWhiteSpace(expression)) throw new ArgumentException();



            // 2. Remove any spaces in the string as calculation will be performed by iterating through chars
            // 3. Find the value of the first number in the expression, will be used as initial sum in calculation
            // 4. Iterate through remaining characters in the expression and update the existing sum value based on the next operator and number
            // 5. return the final sum

            return 0;
        }
    }
}

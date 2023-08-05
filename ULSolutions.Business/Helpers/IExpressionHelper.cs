namespace ULSolutions.Business.Helpers
{
    public interface IExpressionHelper
    {
        double CalculateByOperatorPrecedence(List<string> numbersAndOperators);
        double Evaluate(string expression);
    }
}
namespace CalculatorApp;

public class Calculator
{
    private List<string> history = new List<string>();

    public double Add(double firstNumber, double secondNumber)
    {
        double result = firstNumber + secondNumber;
        history.Add($"{firstNumber} + {secondNumber} = {result}");
        return result;
    }

    public double Subtract(double firstNumber, double secondNumber)
    {
        double result = firstNumber - secondNumber;
        history.Add($"{firstNumber} minus {secondNumber} = {result}");
        return result;
    }

    public double Multiply(double firstNumber, double secondNumber)
    {
        double result = firstNumber * secondNumber;
        history.Add($"{firstNumber} * {secondNumber} = {result}");
        return result;
    }

    public double Divide(double firstNumber, double secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        double result = firstNumber / secondNumber;
        history.Add($"{firstNumber} / {secondNumber} = {result}");
        return result;
    }

    public string[] GetHistory()
    {
        return history.ToArray();
    }
}
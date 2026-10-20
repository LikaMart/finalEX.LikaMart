namespace CalculatorApp;

// ეს არის ჩემი კალკულატორის კლასი, აქ არის ყველა მოქმედება
public class Calculator
{
    // აქ ვინახავ ყველა გამოთვლას რომ მერე ისტორია ვაჩვენო
    // List ავიღე და არა მასივი იმიტომ რომ ზომა წინასწარ არ ვიცი
    private List<string> history = new List<string>();

    // მიმატება, ორ რიცხვს ვკრებ ერთმანეთზე
    public double Add(double firstNumber, double secondNumber)
    {
        double result = firstNumber + secondNumber;
        // ისტორიაში ვამატებ ჩანაწერს რომ მერე გამოჩნდეს რა გამოვთვალე
        history.Add($"{firstNumber} + {secondNumber} = {result}");
        return result;
    }

    // გამოკლება, პირველს ვაკლებ მეორეს
    public double Subtract(double firstNumber, double secondNumber)
    {
        double result = firstNumber - secondNumber;
        // აქაც ვინახავ ისტორიაში, სიტყვის ნაცვლად ნიშანი დავწერე
        history.Add($"{firstNumber} - {secondNumber} = {result}");
        return result;
    }

    // გამრავლება
    public double Multiply(double firstNumber, double secondNumber)
    {
        double result = firstNumber * secondNumber;
        history.Add($"{firstNumber} * {secondNumber} = {result}");
        return result;
    }

    // გაყოფა, აქ ცალკე შემოწმება მჭირდება ნულზე
    public double Divide(double firstNumber, double secondNumber)
    {
        // ნულზე გაყოფა არ შეიძლება ამიტომ ვამოწმებ და ერორს ვისვრი
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        double result = firstNumber / secondNumber;
        history.Add($"{firstNumber} / {secondNumber} = {result}");
        return result;
    }

    // ისტორიას ვაბრუნებ მასივად, ToArray იმიტომ რომ გარედან ვერავინ შეცვალოს ჩემი List
    public string[] GetHistory()
    {
        return history.ToArray();
    }
}

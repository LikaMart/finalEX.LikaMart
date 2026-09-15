using CalculatorApp;

Calculator calculator = new Calculator();
bool running = true;

while (running)
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Subtract");
    Console.WriteLine("3. Multiply");
    Console.WriteLine("4. Divide");
    Console.WriteLine("5. Show History");
    Console.WriteLine("6. Exit");
    Console.Write("Choose operation: ");
    string? choice = Console.ReadLine();

    if (choice == "6")
    {
        running = false;
        continue;
    }

    if (choice == "5")
    {
        string[] history = calculator.GetHistory();
        if (history.Length == 0)
        {
            Console.WriteLine("History is empty");
        }
        else
        {
            foreach (string entry in history)
            {
                Console.WriteLine(entry);
            }
        }
        continue;
    }

    Console.Write("Enter first number: ");
    string? firstInput = Console.ReadLine();
    Console.Write("Enter second number: ");
    string? secondInput = Console.ReadLine();

    bool firstValid = double.TryParse(firstInput, out double firstNumber);
    bool secondValid = double.TryParse(secondInput, out double secondNumber);

    if (!firstValid || !secondValid)
    {
        Console.WriteLine("Invalid number entered");
        continue;
    }

    switch (choice)
    {
        case "1":
            Console.WriteLine($"Result: {calculator.Add(firstNumber, secondNumber)}");
            break;
        case "2":
            Console.WriteLine($"Result: {calculator.Subtract(firstNumber, secondNumber)}");
            break;
        case "3":
            Console.WriteLine($"Result: {calculator.Multiply(firstNumber, secondNumber)}");
            break;
        case "4":
            try
            {
                Console.WriteLine($"Result: {calculator.Divide(firstNumber, secondNumber)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

Console.WriteLine("Program finished");
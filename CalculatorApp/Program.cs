using CalculatorApp;

// კალკულატორის ობიექტს ვქმნი რომ მისი მეთოდები გამოვიყენო
Calculator calculator = new Calculator();
// ეს ცვლადი მჭირდება ციკლის გასაჩერებლად, როცა false გახდება პროგრამა დასრულდება
bool running = true;

// while ციკლი იმიტომ გამოვიყენე რომ მენიუ სულ თავიდან გამოჩნდეს სანამ გამოსვლას არ აირჩევს
while (running)
{
    // მენიუ, სიტყვების ნაცვლად ნიშნები დავწერე
    Console.WriteLine("1. +");
    Console.WriteLine("2. -");
    Console.WriteLine("3. *");
    Console.WriteLine("4. /");
    Console.WriteLine("5. Show History");
    Console.WriteLine("6. Exit");
    Console.Write("Choose operation: ");
    // string? იმიტომ რომ ReadLine შეიძლება null დააბრუნოს
    string? choice = Console.ReadLine();

    // 6 ნიშნავს გამოსვლას
    if (choice == "6")
    {
        running = false;
        // continue რომ ქვემოთ აღარ წავიდეს და ციკლი დასრულდეს
        continue;
    }

    // 5 ნიშნავს ისტორიის ჩვენებას
    if (choice == "5")
    {
        string[] history = calculator.GetHistory();
        // თუ ჯერ არაფერი გამოუთვლია ცარიელი იქნება
        if (history.Length == 0)
        {
            Console.WriteLine("History is empty");
        }
        else
        {
            // ყველა ჩანაწერს სათითაოდ ვბეჭდავ
            foreach (string entry in history)
            {
                Console.WriteLine(entry);
            }
        }
        continue;
    }

    // აქ რიცხვებს ვთხოულობ
    Console.Write("Enter first number: ");
    string? firstInput = Console.ReadLine();
    Console.Write("Enter second number: ");
    string? secondInput = Console.ReadLine();

    // TryParse გამოვიყენე და არა Parse რადგან ასო რომ ჩაწეროს პროგრამა არ გაითიშოს
    bool firstValid = double.TryParse(firstInput, out double firstNumber);
    bool secondValid = double.TryParse(secondInput, out double secondNumber);

    // თუ ერთი მაინც არასწორია თავიდან ვიწყებ
    if (!firstValid || !secondValid)
    {
        Console.WriteLine("Invalid number entered");
        continue;
    }

    // switch ავიღე რადგან ბევრი if-ზე უფრო ლამაზად გამოიყურება
    switch (choice)
    {
        case "1":
            // +
            Console.WriteLine($"Result: {calculator.Add(firstNumber, secondNumber)}");
            break;
        case "2":
            // -
            Console.WriteLine($"Result: {calculator.Subtract(firstNumber, secondNumber)}");
            break;
        case "3":
            // *
            Console.WriteLine($"Result: {calculator.Multiply(firstNumber, secondNumber)}");
            break;
        case "4":
            // გაყოფაზე try catch მჭირდება რადგან ნულზე გაყოფისას ერორს ისვრის
            try
            {
                Console.WriteLine($"Result: {calculator.Divide(firstNumber, secondNumber)}");
            }
            catch (DivideByZeroException ex)
            {
                // ერორის ტექსტს ვუჩვენებ მომხმარებელს
                Console.WriteLine(ex.Message);
            }
            break;
        default:
            // სხვა რამე თუ აირჩია
            Console.WriteLine("Invalid option");
            break;
    }
}

// ციკლიდან რომ გამოვა ეს დაიბეჭდება
Console.WriteLine("Program finished");

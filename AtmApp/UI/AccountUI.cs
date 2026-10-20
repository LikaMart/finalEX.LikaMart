using AtmApp.Extensions;
using AtmApp.Models;
using AtmApp.Services;

namespace AtmApp.UI;

// ანგარიშთან დაკავშირებული ეკრანები, ბალანსი, შეტანა, გატანა
public class AccountUI
{
    // სერვისს კონსტრუქტორში ვიღებ რომ Program-ში შექმნილი იგივე ობიექტი გამოვიყენო
    private UserService userService;

    public AccountUI(UserService userService)
    {
        this.userService = userService;
    }

    // ბალანსის ჩვენება
    public void CheckBalance(User user)
    {
        Console.WriteLine($"Balance: {user.Balance}");
    }

    // თანხის შეტანა
    public void Deposit(User user)
    {
        Console.Write("Enter amount: ");
        string? input = Console.ReadLine();

        // ჯერ null-ზე ვამოწმებ, მერე ჩემს extension მეთოდს ვიძახებ
        if (input != null && input.IsValidAmount(out double amount))
        {
            userService.Deposit(user, amount);
            Console.WriteLine("Deposit successful");
        }
        else
        {
            Console.WriteLine("Invalid amount");
        }
    }

    // თანხის გატანა
    public void Withdraw(User user)
    {
        Console.Write("Enter amount: ");
        string? input = Console.ReadLine();

        if (input != null && input.IsValidAmount(out double amount))
        {
            bool success = userService.Withdraw(user, amount);
            // ? : არის მოკლე if else, თუ წარმატებულია პირველს წერს თუ არა მეორეს
            Console.WriteLine(success ? "Withdrawal successful" : "Insufficient balance");
        }
        else
        {
            Console.WriteLine("Invalid amount");
        }
    }
}

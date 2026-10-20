using AtmApp.Extensions;
using AtmApp.Models;
using AtmApp.Services;

namespace AtmApp.UI;

// სესხების ეკრანები
public class LoanUI
{
    private LoanService loanService;
    // userService აქაც მჭირდება რადგან დამტკიცებისას ბალანსს ვცვლი
    private UserService userService;

    public LoanUI(LoanService loanService, UserService userService)
    {
        this.loanService = loanService;
        this.userService = userService;
    }

    // კლიენტი ითხოვს სესხს
    public void RequestLoan(User user)
    {
        Console.Write("Enter loan amount: ");
        string? input = Console.ReadLine();

        // იგივე შემოწმება როგორც Deposit-ში, დადებითი რიცხვი უნდა იყოს
        if (input != null && input.IsValidAmount(out double amount))
        {
            loanService.RequestLoan(user.Username, amount);
            Console.WriteLine("Loan request submitted");
        }
        else
        {
            Console.WriteLine("Invalid amount");
        }
    }

    // ადმინი ხედავს ყველა დაუმტკიცებელ სესხს
    public void ViewPendingLoans()
    {
        List<LoanRequest> pendingLoans = loanService.GetPendingLoans();

        if (pendingLoans.Count == 0)
        {
            Console.WriteLine("No pending loans");
            // return რომ ქვემოთ აღარ გააგრძელოს
            return;
        }

        foreach (LoanRequest loan in pendingLoans)
        {
            // loan.Id აქ username-ია
            Console.WriteLine($"{loan.Id} requested {loan.Amount}");
        }
    }

    // ადმინი ამტკიცებს სესხს
    public void ApproveLoan()
    {
        Console.Write("Enter username to approve loan: ");
        string? username = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(username))
        {
            bool approved = loanService.ApproveLoan(username, userService);
            Console.WriteLine(approved ? "Loan approved" : "No pending loan found for this user");
        }
    }
}

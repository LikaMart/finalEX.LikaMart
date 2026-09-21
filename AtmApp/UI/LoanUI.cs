using AtmApp.Extensions;
using AtmApp.Models;
using AtmApp.Services;

namespace AtmApp.UI;

public class LoanUI
{
    private LoanService loanService;
    private UserService userService;

    public LoanUI(LoanService loanService, UserService userService)
    {
        this.loanService = loanService;
        this.userService = userService;
    }

    public void RequestLoan(User user)
    {
        Console.Write("Enter loan amount: ");
        string? input = Console.ReadLine();

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

    public void ViewPendingLoans()
    {
        List<LoanRequest> pendingLoans = loanService.GetPendingLoans();

        if (pendingLoans.Count == 0)
        {
            Console.WriteLine("No pending loans");
            return;
        }

        foreach (LoanRequest loan in pendingLoans)
        {
            Console.WriteLine($"{loan.Id} requested {loan.Amount}");
        }
    }

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

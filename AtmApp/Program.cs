using AtmApp.Models;
using AtmApp.Services;
using AtmApp.UI;

UserService userService = new UserService();
LoanService loanService = new LoanService();

AuthUI authUI = new AuthUI(userService);
AccountUI accountUI = new AccountUI(userService);
LoanUI loanUI = new LoanUI(loanService, userService);
AdminUI adminUI = new AdminUI(userService);

bool running = true;

while (running)
{
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");
    Console.Write("Choose option: ");
    string? choice = Console.ReadLine();

    if (choice == "1")
    {
        authUI.Register();
    }
    else if (choice == "2")
    {
        User? loggedInUser = authUI.Login();

        if (loggedInUser == null)
        {
            continue;
        }

        Console.WriteLine($"Welcome {loggedInUser.Username}");
        bool isAdmin = loggedInUser.Role == "admin";
        bool loggedIn = true;

        while (loggedIn)
        {
            if (isAdmin)
            {
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. View Pending Loans");
                Console.WriteLine("5. Approve Loan");
                Console.WriteLine("6. Delete User");
                Console.WriteLine("7. Logout");
            }
            else
            {
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Request Loan");
                Console.WriteLine("5. Logout");
            }

            Console.Write("Choose option: ");
            string? innerChoice = Console.ReadLine();

            if (isAdmin && innerChoice == "7")
            {
                loggedIn = false;
                continue;
            }

            if (!isAdmin && innerChoice == "5")
            {
                loggedIn = false;
                continue;
            }

            switch (innerChoice)
            {
                case "1":
                    accountUI.CheckBalance(loggedInUser);
                    break;
                case "2":
                    accountUI.Deposit(loggedInUser);
                    break;
                case "3":
                    accountUI.Withdraw(loggedInUser);
                    break;
                case "4":
                    if (isAdmin)
                    {
                        loanUI.ViewPendingLoans();
                    }
                    else
                    {
                        loanUI.RequestLoan(loggedInUser);
                    }
                    break;
                case "5":
                    if (isAdmin)
                    {
                        loanUI.ApproveLoan();
                    }
                    break;
                case "6":
                    if (isAdmin)
                    {
                        adminUI.DeleteUser();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
    else if (choice == "3")
    {
        running = false;
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}

Console.WriteLine("Program finished");

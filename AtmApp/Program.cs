using AtmApp.Models;
using AtmApp.Services;
using AtmApp.UI;

// სერვისებს ვქმნი ერთხელ და ყველა UI-ს ერთსა და იმავეს ვაწვდი
// ასე ყველა ერთ მონაცემებთან მუშაობს და არ აირევა
UserService userService = new UserService();
LoanService loanService = new LoanService();

// UI კლასები, თითოეული თავის საქმეს აკეთებს
AuthUI authUI = new AuthUI(userService);
AccountUI accountUI = new AccountUI(userService);
// სესხს ორივე სერვისი სჭირდება რადგან დამტკიცებისას ბალანსიც იცვლება
LoanUI loanUI = new LoanUI(loanService, userService);
AdminUI adminUI = new AdminUI(userService);

// მთავარი ციკლის გასაჩერებლად
bool running = true;

// მთავარი მენიუ, სულ ტრიალებს სანამ Exit-ს არ აირჩევს
while (running)
{
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");
    Console.Write("Choose option: ");
    string? choice = Console.ReadLine();

    if (choice == "1")
    {
        // რეგისტრაცია
        authUI.Register();
    }
    else if (choice == "2")
    {
        // ლოგინი, თუ ვერ შევიდა null დაბრუნდება
        User? loggedInUser = authUI.Login();

        // თუ ვერ შევიდა ისევ მთავარ მენიუში ვაბრუნებ
        if (loggedInUser == null)
        {
            continue;
        }

        Console.WriteLine($"Welcome {loggedInUser.Username}");
        // ვამოწმებ ადმინია თუ არა, ამაზეა დამოკიდებული რა მენიუ გამოჩნდება
        bool isAdmin = loggedInUser.Role == "admin";
        // შიდა ციკლისთვის, logout-ზე false გახდება
        bool loggedIn = true;

        // ეს არის შიდა მენიუ როცა უკვე შესულია
        while (loggedIn)
        {
            if (isAdmin)
            {
                // ადმინს მეტი ფუნქცია აქვს
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
                // ჩვეულებრივი კლიენტის მენიუ
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Request Loan");
                Console.WriteLine("5. Logout");
            }

            Console.Write("Choose option: ");
            string? innerChoice = Console.ReadLine();

            // ადმინისთვის logout არის 7
            if (isAdmin && innerChoice == "7")
            {
                loggedIn = false;
                continue;
            }

            // კლიენტისთვის logout არის 5
            if (!isAdmin && innerChoice == "5")
            {
                loggedIn = false;
                continue;
            }

            // 1, 2, 3 ორივესთვის ერთნაირია, 4-დან უკვე განსხვავდება
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
                    // 4 ადმინისთვის სესხების ნახვაა, კლიენტისთვის სესხის მოთხოვნა
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
                    // სესხის დამტკიცება მხოლოდ ადმინს შეუძლია
                    if (isAdmin)
                    {
                        loanUI.ApproveLoan();
                    }
                    break;
                case "6":
                    // მომხმარებლის წაშლაც მხოლოდ ადმინს
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
        // გამოსვლა პროგრამიდან
        running = false;
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}

Console.WriteLine("Program finished");

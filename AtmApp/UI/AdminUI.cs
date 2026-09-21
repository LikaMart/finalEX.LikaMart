using AtmApp.Services;

namespace AtmApp.UI;

public class AdminUI
{
    private UserService userService;

    public AdminUI(UserService userService)
    {
        this.userService = userService;
    }

    public void DeleteUser()
    {
        Console.Write("Enter username to delete: ");
        string? username = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(username))
        {
            bool deleted = userService.DeleteUser(username);
            Console.WriteLine(deleted ? "User deleted" : "User not found");
        }
    }
}

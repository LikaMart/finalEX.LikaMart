using AtmApp.Services;

namespace AtmApp.UI;

// ადმინის ფუნქციები
public class AdminUI
{
    private UserService userService;

    public AdminUI(UserService userService)
    {
        this.userService = userService;
    }

    // მომხმარებლის წაშლა სახელით
    public void DeleteUser()
    {
        Console.Write("Enter username to delete: ");
        string? username = Console.ReadLine();

        // ცარიელი თუ ჩაწერა არაფერს ვაკეთებ
        if (!string.IsNullOrWhiteSpace(username))
        {
            bool deleted = userService.DeleteUser(username);
            Console.WriteLine(deleted ? "User deleted" : "User not found");
        }
    }
}

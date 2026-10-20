using AtmApp.Consts;
using AtmApp.Models;

namespace AtmApp.Services;

// მომხმარებლების სერვისი, აქ არის რეგისტრაცია, ლოგინი, თანხის შეტანა და გატანა
public class UserService : GenericService<User>
{
    public UserService() : base(FilePaths.UsersFile)
    {
    }

    protected override User Deserialize(string line)
    {
        return User.Deserialize(line);
    }

    // რეგისტრაცია, false აბრუნებს თუ ასეთი username უკვე არსებობს
    public bool Register(string username, string password, string role)
    {
        // ჯერ ვამოწმებ ხომ არ არის დაკავებული
        foreach (User existingUser in items)
        {
            if (existingUser.Username == username)
            {
                return false;
            }
        }

        // ახალ მომხმარებელს ბალანსი 0-დან ეწყება
        User newUser = new User(username, password, 0, role);
        items.Add(newUser);
        Save();
        return true;
    }

    // User? ნიშნავს რომ შეიძლება null დაბრუნდეს თუ ვერ ვიპოვე
    public User? Login(string username, string password)
    {
        foreach (User user in items)
        {
            // ორივე უნდა ემთხვეოდეს
            if (user.Username == username && user.Password == password)
            {
                return user;
            }
        }
        return null;
    }

    // თანხის შეტანა
    public void Deposit(User user, double amount)
    {
        user.Balance += amount;
        Save();
    }

    // თანხის გატანა, bool იმიტომ რომ შეიძლება არ ეყოს ფული
    public bool Withdraw(User user, double amount)
    {
        // ბალანსზე მეტს ვერ გაიტანს
        if (amount > user.Balance)
        {
            return false;
        }
        user.Balance -= amount;
        Save();
        return true;
    }

    // მომხმარებლის წაშლა
    public bool DeleteUser(string username)
    {
        // აქ for გამოვიყენე და არა foreach რადგან foreach-ში წაშლა არ შეიძლება, ინდექსი მჭირდება
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Username == username)
            {
                items.RemoveAt(i);
                Save();
                return true;
            }
        }
        return false;
    }
}

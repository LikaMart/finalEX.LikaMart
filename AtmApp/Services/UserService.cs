using AtmApp.Consts;
using AtmApp.Models;

namespace AtmApp.Services;

public class UserService : GenericService<User>
{
    public UserService() : base(FilePaths.UsersFile)
    {
    }

    protected override User Deserialize(string line)
    {
        return User.Deserialize(line);
    }

    public bool Register(string username, string password, string role)
    {
        foreach (User existingUser in items)
        {
            if (existingUser.Username == username)
            {
                return false;
            }
        }

        User newUser = new User(username, password, 0, role);
        items.Add(newUser);
        Save();
        return true;
    }

    public User? Login(string username, string password)
    {
        foreach (User user in items)
        {
            if (user.Username == username && user.Password == password)
            {
                return user;
            }
        }
        return null;
    }

    public void Deposit(User user, double amount)
    {
        user.Balance += amount;
        Save();
    }

    public bool Withdraw(User user, double amount)
    {
        if (amount > user.Balance)
        {
            return false;
        }
        user.Balance -= amount;
        Save();
        return true;
    }

    public bool DeleteUser(string username)
    {
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

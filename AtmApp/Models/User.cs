namespace AtmApp.Models;

public class User : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public double Balance { get; set; }
    public string Role { get; set; }

    public User(string username, string password, double balance, string role) : base(username)
    {
        Username = username;
        Password = password;
        Balance = balance;
        Role = role;
    }

    public override string Serialize()
    {
        return $"{Username},{Password},{Balance},{Role}";
    }

    public static User Deserialize(string line)
    {
        string[] parts = line.Split(',');
        return new User(parts[0], parts[1], double.Parse(parts[2]), parts[3]);
    }
}

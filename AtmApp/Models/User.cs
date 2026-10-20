namespace AtmApp.Models;

// მომხმარებლის მოდელი
public class User : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    // ბალანსი double-ია რადგან თანხა შეიძლება თეთრებიც იყოს
    public double Balance { get; set; }
    // როლი, client ან admin, ამით ვიგებ რა მენიუ ვაჩვენო
    public string Role { get; set; }

    // username Id-ადაც გამოდის რადგან უნიკალურია
    public User(string username, string password, double balance, string role) : base(username)
    {
        Username = username;
        Password = password;
        Balance = balance;
        Role = role;
    }

    // ფაილში შესანახად ერთ ხაზად ვაქცევ
    public override string Serialize()
    {
        return $"{Username},{Password},{Balance},{Role}";
    }

    // ფაილიდან წაკითხულ ხაზს ისევ User ობიექტად ვაქცევ
    public static User Deserialize(string line)
    {
        string[] parts = line.Split(',');
        // parts[2] ტექსტია ამიტომ double.Parse მჭირდება
        return new User(parts[0], parts[1], double.Parse(parts[2]), parts[3]);
    }
}

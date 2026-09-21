namespace AtmApp.Models;

public class LoanRequest : BaseModel
{
    public double Amount { get; set; }
    public string Status { get; set; }

    public LoanRequest(string username, double amount, string status) : base(username)
    {
        Amount = amount;
        Status = status;
    }

    public override string Serialize()
    {
        return $"{Id},{Amount},{Status}";
    }

    public static LoanRequest Deserialize(string line)
    {
        string[] parts = line.Split(',');
        return new LoanRequest(parts[0], double.Parse(parts[1]), parts[2]);
    }
}

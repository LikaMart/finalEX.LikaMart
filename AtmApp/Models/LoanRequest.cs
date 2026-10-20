namespace AtmApp.Models;

// სესხის მოთხოვნის მოდელი, BaseModel-დან მემკვიდრეობით
public class LoanRequest : BaseModel
{
    // რამდენი თანხა მოითხოვა
    public double Amount { get; set; }
    // სტატუსი, pending ან approved
    public string Status { get; set; }

    // Id-ად username-ს ვაწვდი base-ს, ასე ვიცი ვისია სესხი
    public LoanRequest(string username, double amount, string status) : base(username)
    {
        Amount = amount;
        Status = status;
    }

    // ობიექტს ვაქცევ ერთ ხაზად მძიმეებით რომ ფაილში ჩავწერო
    public override string Serialize()
    {
        return $"{Id},{Amount},{Status}";
    }

    // აქ პირიქით, ფაილის ხაზიდან ვქმნი ობიექტს
    // static იმიტომ რომ ობიექტი ჯერ არ მაქვს და კლასიდან ვიძახებ
    public static LoanRequest Deserialize(string line)
    {
        // მძიმით ვყოფ და ნაწილებს ვიღებ რიგის მიხედვით
        string[] parts = line.Split(',');
        return new LoanRequest(parts[0], double.Parse(parts[1]), parts[2]);
    }
}

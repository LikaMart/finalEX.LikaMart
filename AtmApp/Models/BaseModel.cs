namespace AtmApp.Models;

// abstract კლასი, მისგან ობიექტს ვერ შევქმნი, მხოლოდ მემკვიდრეობით ვიყენებ
// ყველა მოდელს Id სჭირდება ამიტომ აქ დავწერე ერთხელ
public abstract class BaseModel
{
    public string Id { get; set; }

    // protected რადგან კონსტრუქტორს მხოლოდ შვილი კლასები გამოიძახებენ
    protected BaseModel(string id)
    {
        Id = id;
    }

    // ყველა მოდელმა თავისებურად უნდა გადააქციოს თავი ტექსტად ფაილში შესანახად
    public abstract string Serialize();
}

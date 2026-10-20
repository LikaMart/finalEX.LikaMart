namespace BookManagerApp.Models;

// საბაზო კლასი ყველა მოდელისთვის, abstract რადგან პირდაპირ არ ვქმნი
public abstract class BaseModel
{
    public string Id { get; set; }

    protected BaseModel(string id)
    {
        Id = id;
    }

    // ყველა შვილმა კლასმა უნდა დაწეროს როგორ შეინახოს თავი ტექსტად
    public abstract string Serialize();
}

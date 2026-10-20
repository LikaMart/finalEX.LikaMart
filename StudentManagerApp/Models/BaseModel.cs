namespace StudentManagerApp.Models;

// საერთო კლასი მოდელებისთვის, აქ არის Id და Serialize
public abstract class BaseModel
{
    public string Id { get; set; }

    protected BaseModel(string id)
    {
        Id = id;
    }

    // abstract ნიშნავს რომ აქ ტანი არ აქვს და შვილმა უნდა დაწეროს
    public abstract string Serialize();
}

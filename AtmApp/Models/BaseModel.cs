namespace AtmApp.Models;

public abstract class BaseModel
{
    public string Id { get; set; }

    protected BaseModel(string id)
    {
        Id = id;
    }

    public abstract string Serialize();
}

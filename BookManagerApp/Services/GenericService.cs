using BookManagerApp.Helpers;
using BookManagerApp.Models;

namespace BookManagerApp.Services;

public abstract class GenericService<T> where T : BaseModel
{
    protected List<T> items = new List<T>();
    protected string filePath;

    protected GenericService(string filePath)
    {
        this.filePath = filePath;
        Load();
    }

    protected abstract T Deserialize(string line);

    private void Load()
    {
        List<string> lines = FileStreamHelper.ReadLines(filePath);
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                items.Add(Deserialize(line));
            }
        }
    }

    protected void Save()
    {
        List<string> lines = new List<string>();
        foreach (T item in items)
        {
            lines.Add(item.Serialize());
        }
        FileStreamHelper.WriteLines(filePath, lines);
    }

    public List<T> GetAll()
    {
        return items;
    }
}

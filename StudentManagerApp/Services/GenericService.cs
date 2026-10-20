using StudentManagerApp.Helpers;
using StudentManagerApp.Models;

namespace StudentManagerApp.Services;

// ზოგადი სერვისი, ერთხელ დავწერე და ნებისმიერ მოდელზე გამოდგება
public abstract class GenericService<T> where T : BaseModel
{
    protected List<T> items = new List<T>();
    protected string filePath;

    protected GenericService(string filePath)
    {
        this.filePath = filePath;
        // დაწყებისთანავე ფაილიდან ვტვირთავ
        Load();
    }

    // როგორ გადაიქცეს ხაზი ობიექტად, ამას შვილი კლასი წყვეტს
    protected abstract T Deserialize(string line);

    private void Load()
    {
        List<string> lines = FileStreamHelper.ReadLines(filePath);
        foreach (string line in lines)
        {
            // ცარიელი ხაზები რომ არ დაემატოს
            if (!string.IsNullOrWhiteSpace(line))
            {
                items.Add(Deserialize(line));
            }
        }
    }

    // ცვლილების მერე ყოველთვის ვინახავ
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

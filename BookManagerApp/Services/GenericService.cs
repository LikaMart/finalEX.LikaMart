using BookManagerApp.Helpers;
using BookManagerApp.Models;

namespace BookManagerApp.Services;

// ზოგადი სერვისი ნებისმიერი მოდელისთვის
// T : BaseModel იმიტომ რომ Serialize ყველა T-ს ჰქონდეს
public abstract class GenericService<T> where T : BaseModel
{
    // ყველა ელემენტი მეხსიერებაში
    protected List<T> items = new List<T>();
    protected string filePath;

    // როგორც კი სერვისი შეიქმნება ფაილიდან ვკითხულობ
    protected GenericService(string filePath)
    {
        this.filePath = filePath;
        Load();
    }

    // ამას შვილი კლასი დაწერს
    protected abstract T Deserialize(string line);

    private void Load()
    {
        List<string> lines = FileStreamHelper.ReadLines(filePath);
        foreach (string line in lines)
        {
            // ცარიელ ხაზს ვტოვებ
            if (!string.IsNullOrWhiteSpace(line))
            {
                items.Add(Deserialize(line));
            }
        }
    }

    // ყველაფერს ტექსტად ვაქცევ და ფაილში ვწერ
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

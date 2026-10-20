using AtmApp.Helpers;
using AtmApp.Models;

namespace AtmApp.Services;

// ზოგადი სერვისი, T ნებისმიერი მოდელი შეიძლება იყოს
// where T : BaseModel ნიშნავს რომ T აუცილებლად BaseModel-ის შვილი უნდა იყოს, ასე Serialize-ს გამოვიძახებ
// ეს იმიტომ გავაკეთე რომ ფაილიდან წაკითხვა და შენახვა ყველა სერვისში თავიდან არ დამეწერა
public abstract class GenericService<T> where T : BaseModel
{
    // protected რომ შვილ კლასებს ჰქონდეთ წვდომა
    protected List<T> items = new List<T>();
    protected string filePath;

    // სერვისის შექმნისთანავე ფაილიდან ვტვირთავ მონაცემებს
    protected GenericService(string filePath)
    {
        this.filePath = filePath;
        Load();
    }

    // ყველა სერვისი თავად წყვეტს როგორ გადააქციოს ხაზი ობიექტად
    protected abstract T Deserialize(string line);

    // ფაილიდან ჩატვირთვა
    private void Load()
    {
        List<string> lines = FileStreamHelper.ReadLines(filePath);
        foreach (string line in lines)
        {
            // ცარიელ ხაზებს ვტოვებ თორემ Deserialize ერორს ამოაგდებს
            if (!string.IsNullOrWhiteSpace(line))
            {
                items.Add(Deserialize(line));
            }
        }
    }

    // ყველა ცვლილების მერე ვიძახებ რომ ფაილშიც შეინახოს
    protected void Save()
    {
        List<string> lines = new List<string>();
        foreach (T item in items)
        {
            lines.Add(item.Serialize());
        }
        FileStreamHelper.WriteLines(filePath, lines);
    }

    // ყველა ელემენტს აბრუნებს
    public List<T> GetAll()
    {
        return items;
    }
}

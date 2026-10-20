namespace BookManagerApp.Models;

// წიგნის მოდელი
public class Book : BaseModel
{
    public string Title { get; set; }
    public string Author { get; set; }
    // წელი int-ია რადგან მთელი რიცხვია
    public int Year { get; set; }

    // Id-ად სათაურს ვიყენებ
    public Book(string title, string author, int year) : base(title)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    // ფაილში ასე ინახება: სათაური,ავტორი,წელი
    public override string Serialize()
    {
        return $"{Title},{Author},{Year}";
    }

    // ფაილის ხაზიდან წიგნის ობიექტს ვქმნი
    public static Book Deserialize(string line)
    {
        string[] parts = line.Split(',');
        return new Book(parts[0], parts[1], int.Parse(parts[2]));
    }

    // ToString-ს ვცვლი რომ Console.WriteLine(book) ლამაზად დაბეჭდოს და არა კლასის სახელი
    // \" იმიტომ წერია რომ სათაური ბრჭყალებში გამოჩნდეს
    public override string ToString()
    {
        return $"\"{Title}\" by {Author} ({Year})";
    }
}

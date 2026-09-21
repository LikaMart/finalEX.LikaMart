namespace BookManagerApp.Models;

public class Book : BaseModel
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year) : base(title)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string Serialize()
    {
        return $"{Title},{Author},{Year}";
    }

    public static Book Deserialize(string line)
    {
        string[] parts = line.Split(',');
        return new Book(parts[0], parts[1], int.Parse(parts[2]));
    }

    public override string ToString()
    {
        return $"\"{Title}\" by {Author} ({Year})";
    }
}

using BookManagerApp.Consts;
using BookManagerApp.Models;

namespace BookManagerApp.Services;

// წიგნების სერვისი, ჩატვირთვა და შენახვა GenericService-დან მოდის
public class BookService : GenericService<Book>
{
    public BookService() : base(FilePaths.BooksFile)
    {
    }

    protected override Book Deserialize(string line)
    {
        return Book.Deserialize(line);
    }

    // ახალი წიგნის დამატება და მაშინვე ფაილში შენახვა
    public void AddBook(string title, string author, int year)
    {
        Book book = new Book(title, author, year);
        items.Add(book);
        Save();
    }

    // სათაურით ძებნა, List-ს ვაბრუნებ რადგან რამდენიმე წიგნი შეიძლება მოიძებნოს
    public List<Book> SearchByTitle(string title)
    {
        List<Book> results = new List<Book>();
        foreach (Book book in items)
        {
            // Contains რომ სათაურის ნაწილითაც იპოვოს
            // OrdinalIgnoreCase ნიშნავს რომ დიდ და პატარა ასოებს არ განასხვავებს
            if (book.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(book);
            }
        }
        return results;
    }
}

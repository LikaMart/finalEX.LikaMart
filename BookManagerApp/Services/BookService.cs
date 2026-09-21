using BookManagerApp.Consts;
using BookManagerApp.Models;

namespace BookManagerApp.Services;

public class BookService : GenericService<Book>
{
    public BookService() : base(FilePaths.BooksFile)
    {
    }

    protected override Book Deserialize(string line)
    {
        return Book.Deserialize(line);
    }

    public void AddBook(string title, string author, int year)
    {
        Book book = new Book(title, author, year);
        items.Add(book);
        Save();
    }

    public List<Book> SearchByTitle(string title)
    {
        List<Book> results = new List<Book>();
        foreach (Book book in items)
        {
            if (book.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(book);
            }
        }
        return results;
    }
}

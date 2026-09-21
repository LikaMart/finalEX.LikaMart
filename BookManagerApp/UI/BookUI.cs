using BookManagerApp.Extensions;
using BookManagerApp.Models;
using BookManagerApp.Services;

namespace BookManagerApp.UI;

public class BookUI
{
    private BookService bookService;

    public BookUI(BookService bookService)
    {
        this.bookService = bookService;
    }

    public void AddBook()
    {
        Console.Write("Enter title: ");
        string? title = Console.ReadLine();

        while (title == null || !title.IsValidText())
        {
            Console.Write("Title cannot be empty. Enter title: ");
            title = Console.ReadLine();
        }

        Console.Write("Enter author: ");
        string? author = Console.ReadLine();

        while (author == null || !author.IsValidText())
        {
            Console.Write("Author cannot be empty. Enter author: ");
            author = Console.ReadLine();
        }

        Console.Write("Enter publication year: ");
        string? yearInput = Console.ReadLine();

        while (yearInput == null || !yearInput.IsValidYear(out int _))
        {
            Console.Write($"Invalid year. Enter a whole number between 1 and {DateTime.Now.Year}: ");
            yearInput = Console.ReadLine();
        }

        yearInput.IsValidYear(out int year);

        bookService.AddBook(title, author, year);
        Console.WriteLine("Book added successfully");
    }

    public void ViewAllBooks()
    {
        List<Book> books = bookService.GetAll();

        if (books.Count == 0)
        {
            Console.WriteLine("No books in the list");
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i]}");
        }
    }

    public void SearchBook()
    {
        Console.Write("Enter title to search: ");
        string? title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Search text cannot be empty");
            return;
        }

        List<Book> results = bookService.SearchByTitle(title);

        if (results.Count == 0)
        {
            Console.WriteLine("No book found with that title");
            return;
        }

        foreach (Book book in results)
        {
            Console.WriteLine(book);
        }
    }
}

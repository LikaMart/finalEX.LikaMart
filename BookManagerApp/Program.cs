using BookManagerApp.Services;
using BookManagerApp.UI;

BookService bookService = new BookService();
BookUI bookUI = new BookUI(bookService);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. View All Books");
    Console.WriteLine("3. Search Book by Title");
    Console.WriteLine("4. Exit");
    Console.Write("Choose option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            bookUI.AddBook();
            break;
        case "2":
            bookUI.ViewAllBooks();
            break;
        case "3":
            bookUI.SearchBook();
            break;
        case "4":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

Console.WriteLine("Program finished");

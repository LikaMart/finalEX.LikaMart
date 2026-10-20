using BookManagerApp.Services;
using BookManagerApp.UI;

// სერვისს ვქმნი და UI-ს ვაწვდი
BookService bookService = new BookService();
BookUI bookUI = new BookUI(bookService);

// ციკლის გასაჩერებლად
bool running = true;

// მენიუ მეორდება სანამ Exit არ აირჩევა
while (running)
{
    // ცარიელი ხაზი რომ მენიუ წინა ტექსტს არ მიეწებოს
    Console.WriteLine();
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. View All Books");
    Console.WriteLine("3. Search Book by Title");
    Console.WriteLine("4. Exit");
    Console.Write("Choose option: ");
    string? choice = Console.ReadLine();

    // არჩევანის მიხედვით შესაბამის მეთოდს ვიძახებ
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
            // გამოსვლა
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

Console.WriteLine("Program finished");

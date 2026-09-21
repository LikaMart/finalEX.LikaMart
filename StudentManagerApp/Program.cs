using StudentManagerApp.Services;
using StudentManagerApp.UI;

StudentService studentService = new StudentService();
StudentUI studentUI = new StudentUI(studentService);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("1. Add New Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Student by Roll Number");
    Console.WriteLine("4. Update Student Grade");
    Console.WriteLine("5. Exit");
    Console.Write("Choose option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            studentUI.AddStudent();
            break;
        case "2":
            studentUI.ViewAllStudents();
            break;
        case "3":
            studentUI.SearchStudent();
            break;
        case "4":
            studentUI.UpdateGrade();
            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

Console.WriteLine("Program finished");

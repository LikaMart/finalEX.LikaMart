using StudentManagerApp.Extensions;
using StudentManagerApp.Models;
using StudentManagerApp.Services;

namespace StudentManagerApp.UI;

// სტუდენტების მენიუს ფუნქციები, აქ ვკითხულობ და ვბეჭდავ
public class StudentUI
{
    private StudentService studentService;

    public StudentUI(StudentService studentService)
    {
        this.studentService = studentService;
    }

    public void AddStudent()
    {
        Console.Write("Enter name: ");
        string? name = Console.ReadLine();

        // სანამ სახელს არ ჩაწერს ისევ ვკითხავ
        while (name == null || !name.IsValidText())
        {
            Console.Write("Name cannot be empty. Enter name: ");
            name = Console.ReadLine();
        }

        Console.Write("Enter roll number: ");
        string? rollInput = Console.ReadLine();

        // აქ მხოლოდ ვამოწმებ სწორია თუ არა, ამიტომ _ ვწერ
        while (rollInput == null || !rollInput.IsValidRollNumber(out int _))
        {
            Console.Write("Invalid roll number. Enter a positive whole number: ");
            rollInput = Console.ReadLine();
        }
        // აქ უკვე რიცხვს ვიღებ
        rollInput.IsValidRollNumber(out int rollNumber);

        Console.Write("Enter grade (A/B/C/D/F): ");
        string? gradeInput = Console.ReadLine();

        // ნიშანზეც იგივე პრინციპი
        while (gradeInput == null || !gradeInput.IsValidGrade(out char _))
        {
            Console.Write("Invalid grade. Enter one of A, B, C, D, F: ");
            gradeInput = Console.ReadLine();
        }
        gradeInput.IsValidGrade(out char grade);

        bool added = studentService.AddStudent(name, rollNumber, grade);
        // თუ ნომერი დაკავებულია ამას ვეუბნები
        Console.WriteLine(added
            ? "Student added successfully"
            : $"A student with roll number {rollNumber} already exists");
    }

    // ყველა სტუდენტის სია
    public void ViewAllStudents()
    {
        List<Student> students = studentService.GetAll();

        if (students.Count == 0)
        {
            Console.WriteLine("No students in the list");
            return;
        }

        foreach (Student student in students)
        {
            // Student-ში ToString გადავაკეთე ამიტომ ლამაზად დაიბეჭდება
            Console.WriteLine(student);
        }
    }

    // ნომრით ძებნა
    public void SearchStudent()
    {
        Console.Write("Enter roll number to search: ");
        string? rollInput = Console.ReadLine();

        // აქ while არ მჭირდება, თუ არასწორია უბრალოდ გამოვდივარ
        if (rollInput == null || !rollInput.IsValidRollNumber(out int rollNumber))
        {
            Console.WriteLine("Invalid roll number");
            return;
        }

        Student? student = studentService.SearchByRollNumber(rollNumber);

        if (student == null)
        {
            Console.WriteLine("No student found with that roll number");
            return;
        }

        Console.WriteLine(student);
    }

    // ნიშნის შეცვლა
    public void UpdateGrade()
    {
        Console.Write("Enter roll number of the student to update: ");
        string? rollInput = Console.ReadLine();

        if (rollInput == null || !rollInput.IsValidRollNumber(out int rollNumber))
        {
            Console.WriteLine("Invalid roll number");
            return;
        }

        // ჯერ ვამოწმებ არსებობს თუ არა რომ ნიშანი ტყუილად არ ვკითხო
        if (studentService.SearchByRollNumber(rollNumber) == null)
        {
            Console.WriteLine("No student found with that roll number");
            return;
        }

        Console.Write("Enter new grade (A/B/C/D/F): ");
        string? gradeInput = Console.ReadLine();

        while (gradeInput == null || !gradeInput.IsValidGrade(out char _))
        {
            Console.Write("Invalid grade. Enter one of A, B, C, D, F: ");
            gradeInput = Console.ReadLine();
        }
        gradeInput.IsValidGrade(out char grade);

        studentService.UpdateGrade(rollNumber, grade);
        Console.WriteLine("Grade updated successfully");
    }
}

using StudentManagerApp.Extensions;
using StudentManagerApp.Models;
using StudentManagerApp.Services;

namespace StudentManagerApp.UI;

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

        while (name == null || !name.IsValidText())
        {
            Console.Write("Name cannot be empty. Enter name: ");
            name = Console.ReadLine();
        }

        Console.Write("Enter roll number: ");
        string? rollInput = Console.ReadLine();

        while (rollInput == null || !rollInput.IsValidRollNumber(out int _))
        {
            Console.Write("Invalid roll number. Enter a positive whole number: ");
            rollInput = Console.ReadLine();
        }
        rollInput.IsValidRollNumber(out int rollNumber);

        Console.Write("Enter grade (A/B/C/D/F): ");
        string? gradeInput = Console.ReadLine();

        while (gradeInput == null || !gradeInput.IsValidGrade(out char _))
        {
            Console.Write("Invalid grade. Enter one of A, B, C, D, F: ");
            gradeInput = Console.ReadLine();
        }
        gradeInput.IsValidGrade(out char grade);

        bool added = studentService.AddStudent(name, rollNumber, grade);
        Console.WriteLine(added
            ? "Student added successfully"
            : $"A student with roll number {rollNumber} already exists");
    }

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
            Console.WriteLine(student);
        }
    }

    public void SearchStudent()
    {
        Console.Write("Enter roll number to search: ");
        string? rollInput = Console.ReadLine();

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

    public void UpdateGrade()
    {
        Console.Write("Enter roll number of the student to update: ");
        string? rollInput = Console.ReadLine();

        if (rollInput == null || !rollInput.IsValidRollNumber(out int rollNumber))
        {
            Console.WriteLine("Invalid roll number");
            return;
        }

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

using StudentManagerApp.Consts;
using StudentManagerApp.Models;

namespace StudentManagerApp.Services;

// სტუდენტების სერვისი, დამატება, ძებნა და ნიშნის შეცვლა
public class StudentService : GenericService<Student>
{
    public StudentService() : base(FilePaths.StudentsFile)
    {
    }

    protected override Student Deserialize(string line)
    {
        return Student.Deserialize(line);
    }

    // false-ს აბრუნებს თუ ასეთი ნომრით სტუდენტი უკვე არის
    public bool AddStudent(string name, int rollNumber, char grade)
    {
        // ნომერი არ უნდა გამეორდეს
        foreach (Student existingStudent in items)
        {
            if (existingStudent.RollNumber == rollNumber)
            {
                return false;
            }
        }

        Student student = new Student(name, rollNumber, grade);
        items.Add(student);
        Save();
        return true;
    }

    // ნომრით ძებნა, ერთი სტუდენტი ან null
    public Student? SearchByRollNumber(int rollNumber)
    {
        foreach (Student student in items)
        {
            if (student.RollNumber == rollNumber)
            {
                return student;
            }
        }
        return null;
    }

    // ნიშნის განახლება
    public bool UpdateGrade(int rollNumber, char newGrade)
    {
        // ძებნის მეთოდს თავიდან არ ვწერ, უკვე არსებულს ვიყენებ
        Student? student = SearchByRollNumber(rollNumber);

        if (student == null)
        {
            return false;
        }

        // ობიექტი რეფერენსით მოდის, ამიტომ აქ შეცვლა List-შიც შეიცვლება
        student.Grade = newGrade;
        Save();
        return true;
    }
}

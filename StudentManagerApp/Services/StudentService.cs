using StudentManagerApp.Consts;
using StudentManagerApp.Models;

namespace StudentManagerApp.Services;

public class StudentService : GenericService<Student>
{
    public StudentService() : base(FilePaths.StudentsFile)
    {
    }

    protected override Student Deserialize(string line)
    {
        return Student.Deserialize(line);
    }

    public bool AddStudent(string name, int rollNumber, char grade)
    {
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

    public bool UpdateGrade(int rollNumber, char newGrade)
    {
        Student? student = SearchByRollNumber(rollNumber);

        if (student == null)
        {
            return false;
        }

        student.Grade = newGrade;
        Save();
        return true;
    }
}

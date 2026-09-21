namespace StudentManagerApp.Models;

public class Student : BaseModel
{
    public string Name { get; set; }
    public int RollNumber { get; set; }
    public char Grade { get; set; }

    public Student(string name, int rollNumber, char grade) : base(rollNumber.ToString())
    {
        Name = name;
        RollNumber = rollNumber;
        Grade = grade;
    }

    public override string Serialize()
    {
        return $"{Name},{RollNumber},{Grade}";
    }

    public static Student Deserialize(string line)
    {
        string[] parts = line.Split(',');
        return new Student(parts[0], int.Parse(parts[1]), parts[2][0]);
    }

    public override string ToString()
    {
        return $"Roll No. {RollNumber} - {Name} (Grade: {Grade})";
    }
}

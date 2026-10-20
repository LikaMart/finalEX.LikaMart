namespace StudentManagerApp.Models;

// სტუდენტის მოდელი
public class Student : BaseModel
{
    public string Name { get; set; }
    // სიის ნომერი, ეს უნიკალურია ყველა სტუდენტისთვის
    public int RollNumber { get; set; }
    // ნიშანი char-ია რადგან ერთი ასოა
    public char Grade { get; set; }

    // Id სტრინგია ამიტომ ნომერს ToString-ით ვაქცევ
    public Student(string name, int rollNumber, char grade) : base(rollNumber.ToString())
    {
        Name = name;
        RollNumber = rollNumber;
        Grade = grade;
    }

    // ფაილში შესანახი ფორმატი
    public override string Serialize()
    {
        return $"{Name},{RollNumber},{Grade}";
    }

    public static Student Deserialize(string line)
    {
        string[] parts = line.Split(',');
        // parts[2][0] ნიშნავს მესამე ნაწილის პირველ სიმბოლოს, ასე სტრინგიდან char-ს ვიღებ
        return new Student(parts[0], int.Parse(parts[1]), parts[2][0]);
    }

    // დასაბეჭდად ლამაზი ფორმატი
    public override string ToString()
    {
        return $"Roll No. {RollNumber} - {Name} (Grade: {Grade})";
    }
}

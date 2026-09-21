# StudentManagerApp

სტუდენტების მართვის კონსოლ აპლიკაცია, `finalEX.LikaMart` repo-ს `AtmApp`/`BookManagerApp`-ის
იდენტური არქიტექტურით: ფენებად დაყოფილი კოდი (`Models` / `Services` / `UI` / `Helpers` /
`Extensions` / `Consts`), `BaseModel` + `GenericService<T>` და შენახვა ტექსტურ ფაილში
(`students.txt`).

## სტრუქტურა

- `Models/BaseModel.cs` — აბსტრაქტული საბაზისო კლასი (`Id`, აბსტრაქტული `Serialize()`).
- `Models/Student.cs` — `BaseModel`-ის მემკვიდრე; `Name`, `RollNumber`, `Grade` (char);
  `Id` = `RollNumber` (string-ად); `Serialize`/`Deserialize` CSV ფორმატისთვის; `ToString()`
  override-ით (პოლიმორფიზმი) ლამაზი გამოსატანად.
- `Services/GenericService.cs` — გენერიკული საბაზისო სერვისი ფაილიდან ჩატვირთვა/შენახვისთვის.
- `Services/StudentService.cs` — `AddStudent` (სიის ნომრის უნიკალურობის შემოწმებით),
  `SearchByRollNumber`, `UpdateGrade`, `GetAll` (მემკვიდრეობით).
- `Extensions/StringExtensions.cs` — `IsValidText`, `IsValidRollNumber`, `IsValidGrade`
  (A/B/C/D/F).
- `Helpers/FileStreamHelper.cs`, `Consts/FilePaths.cs` — ფაილთან მუშაობა (`students.txt`).
- `UI/StudentUI.cs` — კონსოლის ურთიერთქმედება, ვალიდაციის ციკლებით.
- `Program.cs` — მენიუს ციკლი (top-level statements).

## მენიუ

1. ახალი სტუდენტის დამატება
2. ყველა სტუდენტის ნახვა
3. სტუდენტის ძებნა სიის ნომრით
4. სტუდენტის შეფასების განახლება
5. გასვლა

## გაშვება

```bash
cd StudentManagerApp
dotnet run
```

## მაგალითი (ტესტირებულია რეალურ გაშვებაზე)

```
1. Add New Student
2. View All Students
3. Search Student by Roll Number
4. Update Student Grade
5. Exit
Choose option: 1
Enter name:                         <- ცარიელი შეყვანა
Name cannot be empty. Enter name: Nino Beridze
Enter roll number: abc              <- არასწორი ფორმატი
Invalid roll number. Enter a positive whole number: 101
Enter grade (A/B/C/D/F): Z          <- დაუშვებელი შეფასება
Invalid grade. Enter one of A, B, C, D, F: B
Student added successfully

Choose option: 1
Enter name: Giorgi
Enter roll number: 101              <- უკვე დაკავებული ნომერი
Enter grade (A/B/C/D/F): A
A student with roll number 101 already exists

Choose option: 3
Enter roll number to search: 101
Roll No. 101 - Nino Beridze (Grade: B)

Choose option: 4
Enter roll number of the student to update: 101
Enter new grade (A/B/C/D/F): F
Grade updated successfully

Choose option: 2
Roll No. 101 - Nino Beridze (Grade: F)

Choose option: 5
Program finished
```

## OOP პრინციპები

- **ინკაფსულაცია:** `GenericService<T>`-ის `items`/`filePath` — `protected`; მონაცემებთან
  წვდომა მხოლოდ საჯარო მეთოდებით (`AddStudent`, `SearchByRollNumber`, `UpdateGrade`).
- **მემკვიდრეობა:** `Student : BaseModel`, `StudentService : GenericService<Student>`.
- **პოლიმორფიზმი:** `BaseModel.Serialize()` აბსტრაქტულია და `Student`-ში override-ულია;
  `Student.ToString()` override-ული, ისე რომ `Console.WriteLine(student)` სწორ ფორმატში
  გამოაქვს ინფორმაცია.
- **ვალიდაცია:** სახელი — არ შეიძლება იყოს ცარიელი; სიის ნომერი — დადებითი მთელი
  რიცხვი (და უნიკალური დამატებისას); შეფასება — მხოლოდ A/B/C/D/F — ყველა UI მეთოდში
  ციკლური ხელახალი მოთხოვნით არასწორი შეყვანისას.

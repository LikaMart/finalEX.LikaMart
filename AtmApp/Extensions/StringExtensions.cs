namespace AtmApp.Extensions;

// ეს არის extension მეთოდების კლასი, static უნდა იყოს აუცილებლად
public static class StringExtensions
{
    // this string ნიშნავს რომ ამ მეთოდს პირდაპირ სტრინგზე გამოვიძახებ, მაგალითად input.IsValidAmount()
    // out იმიტომ ვიყენებ რომ რიცხვიც დავაბრუნო და true/false-იც
    public static bool IsValidAmount(this string input, out double amount)
    {
        // ჯერ ვამოწმებ რიცხვია თუ არა
        bool isNumber = double.TryParse(input, out amount);
        // თანხა ნულზე მეტი უნდა იყოს, უარყოფითი თანხის შეტანა არ შეიძლება
        return isNumber && amount > 0;
    }
}

using HangmanApp;

// თავიდან true რომ ერთხელ მაინც ითამაშოს
bool playAgain = true;

while (playAgain)
{
    // ყოველ ჯერზე ახალ თამაშს ვქმნი რომ ახალი სიტყვა აირჩიოს
    HangmanGame game = new HangmanGame();
    game.Play();

    Console.Write("Play again? (y/n): ");
    string? answer = Console.ReadLine();
    // მხოლოდ y-ზე გააგრძელებს, ToLower რომ Y-იც ჩაითვალოს
    playAgain = answer != null && answer.ToLower() == "y";
}

Console.WriteLine("Program finished");

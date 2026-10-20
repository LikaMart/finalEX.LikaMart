using NumberGuessApp;

bool playAgain = true;

// თამაში მეორდება სანამ y-ს წერს
while (playAgain)
{
    // 1-დან 100-მდე, ყოველ ჯერზე ახალი რიცხვი იქნება
    NumberGuessGame game = new NumberGuessGame(1, 100);
    game.Play();

    Console.Write("Play again? (y/n): ");
    string? answer = Console.ReadLine();
    // null-ზე ჯერ ვამოწმებ თორემ ToLower ერორს ამოაგდებს
    playAgain = answer != null && answer.ToLower() == "y";
}

Console.WriteLine("Program finished");

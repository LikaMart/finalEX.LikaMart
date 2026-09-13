using NumberGuessApp;

bool playAgain = true;

while (playAgain)
{
    NumberGuessGame game = new NumberGuessGame(1, 100);
    game.Play();

    Console.Write("Play again? (y/n): ");
    string? answer = Console.ReadLine();
    playAgain = answer != null && answer.ToLower() == "y";
}

Console.WriteLine("Program finished");
using HangmanApp;

bool playAgain = true;

while (playAgain)
{
    HangmanGame game = new HangmanGame();
    game.Play();

    Console.Write("Play again? (y/n): ");
    string? answer = Console.ReadLine();
    playAgain = answer != null && answer.ToLower() == "y";
}

Console.WriteLine("Program finished");
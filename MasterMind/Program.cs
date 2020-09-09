using System;

namespace MasterMind
{
  class Program
  {
    static void Main(string[] args)
    {
      Program.Run();
    }

    public static void Run()
    {
      Console.WriteLine("Mastermind");
      var newGame = new Game();
      while (newGame.GuessCount < 60)
      {
        Console.WriteLine("Enter your guess of four colours");
        var guess = Console.ReadLine();

        Console.WriteLine(newGame.ResponseToPlayer(guess));

        newGame.GuessCount++;
      }
      Console.WriteLine("You have guessed 60 times");

    }

  }
}
using System;

namespace MasterMind
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Mastermind");
      var newGame = new Game();
          while (newGame.GuessCount < 60)
          {
               var guess = Console.ReadLine();
      var validGuess = newGame.TakeGuess(guess);
      var response = newGame.Check(validGuess);
      newGame.GuessCount++;
          }
  
  
    }
  }
}
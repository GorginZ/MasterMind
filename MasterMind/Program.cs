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
Console.WriteLine("Enter your guess of four colours");
var guess = Console.ReadLine();
        //is this dumb?
        //how to re-ask what's the  most appropriate way to do this

       if (!newGame.TryParseGuess(guess, out var validGuess))
       {
         Console.WriteLine(" please enter a guess of four valid colours");
         continue;
         
       }

       var responseArray = newGame.Check(validGuess);
       var responseOutput = String.Join(", ", responseArray);
       Console.WriteLine(responseOutput);




        // var validGuess = newGame.TakeGuess(guess);
        // var response = newGame.Check(validGuess);
        newGame.GuessCount++;
      }
Console.WriteLine("You have guessed 60 times");

    }
  }
}
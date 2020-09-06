using System;

namespace MasterMind
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      var newGame = new Game();
      var guess = new[] { Colours.Blue, Colours.Purple, Colours.Purple, Colours.Purple };

      var response = newGame.Check(guess);
    
        }
  }
}
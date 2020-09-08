using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
  public class Game
  {

    public Colours[] Code { get; set; }

    public IUserInput UserInput { get; set; }

    public int GuessCount { get; set; }


    public Game() : this(Game.RandomCodeFactory, new ConsoleUserInput())
    { }

    public Game(System.Func<Colours[]> codeFactory, IUserInput userInput)
    {
      Code = codeFactory();
      UserInput = userInput;
    }

    public static Colours[] FixedCodeFactory()
    {
      var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };

      return code;
    }

    public static Colours[] RandomCodeFactory()
    {
      var rng = new System.Random();
      var code = new Colours[4];
      for (var i = 0; i < code.Length; ++i)
      {
        code[i] = (Colours)rng.Next((int)Colours.MinValue, (int)Colours.MaxValue + 1);
      }
      return code;
    }


    public bool CheckGuessLength(Colours[] guess)
    {
      if (guess.Length != 4)
      {
      Console.WriteLine("You must enter four colours per guess");
      return false;
      }
      return true;

    }

    public Colours[] TakeGuess(string guess)
    {
      // var consoleUserInput = new ConsoleUserInput();
      var isValidGuess = TryParseGuess(guess, out Colours[] validGuess);
      return validGuess;

    }

    public bool TryParseGuess(string guess, out Colours[] validGuess)
    {
      validGuess = null;

      var guessArr = guess.Split(", ");
      if (guessArr.Length != 4)
      {
        return false;
      }

      var parsedColours = new Colours[4];
      for (int i = 0; i < guessArr.Length; i++)
      {
        if (Enum.TryParse(guessArr[i], out Colours colour))
        {
          parsedColours[i] = colour;
        }
        else
        {
          return false;
        }

      }
    
      validGuess = parsedColours;
      return true;
    }


    public ResponseColours[] Check(Colours[] guess)
    {
      var responseColours = new List<ResponseColours>();
      for (int i = 0; i < Code.Length; i++)
      {
        if (guess[i].Equals(Code[i]))
        {
          responseColours.Add(ResponseColours.Black);
        }
        // 
        else if (Code.Contains(guess[i]))
        {
          responseColours.Add(ResponseColours.White);
        }
      }

      return responseColours.ToArray();
    }
  }
}


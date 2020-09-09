using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
  public class Game
  {

    public Colours[] Code { get; set; }

    // public IUserInput UserInput { get; set; }

    public int GuessCount { get; set; }


    public Game() : this(Game.RandomCodeFactory)
    { }

    public Game(System.Func<Colours[]> codeFactory)
    {
      Code = codeFactory();
      // UserInput = userInput;
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

    // public Colours[] TakeGuess(string guess)
    // {
    //   // var consoleUserInput = new ConsoleUserInput();
    //   var isValidGuess = TryParseGuess(guess, out Colours[] validGuess);
    //   return validGuess;

    // }

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

    public bool WillThisColourReturnAnyBlacks(Colours colour, int position)
    {
      for (int i = 0; i < Code.Length; i++)
      {
        if (colour == Code[i] && i != position)
        {

          return true;
        }

      }
      return false;
    }
    // public ResponseColours[] Check(Colours[] guess)
    // {
    //   var responseColours = new List<ResponseColours>();
    //   for (int i = 0; i < Code.Length; i++)
    //   {
    //     if (guess[i].Equals(Code[i]))
    //     {
    //       responseColours.Add(ResponseColours.Black);

    //     }

    //     else if (Code.Contains(guess[i]) && !WillThisColourReturnAnyBlacks(guess[i], i))

    //     {
    //       responseColours.Add(ResponseColours.White);

    //     }
    //   }
    //   return responseColours.ToArray();
    // }

    public ResponseColours[] Check(Colours[] guess)
    {
      var responseColours = new List<ResponseColours>();
      for (int i = 0; i < Code.Length; i++)
      {
        var checkListCode = Code;

          if (guess[i].Equals(Code[i]))
          {
            responseColours.Add(ResponseColours.Black);
            checkListCode[i] = Colours.Tick;

          }
          else if (Code.Contains(guess[i]))
        
          {
            responseColours.Add(ResponseColours.White);

          }

        

      }
      return responseColours.ToArray();

    }
    // public ResponseColours[] Check(Colours[] guess)
    // {
    //   var responseColours = new List<ResponseColours>();

    //   var CodeIntersectGuess = Code.Intersect(guess);


    //     for (int i = 0; i < Code.Length; i++)
    //     {
    //       if (guess[i].Equals(Code[i]))
    //       {
    //         responseColours.Add(ResponseColours.Black);

    //       }
    //       else
    //       {
    //         responseColours.Add(ResponseColours.White);
    //       }
    //     }


    //   return responseColours.ToArray();
    // }

    public string ResponseToPlayer(string guess)
    {
      if (!TryParseGuess(guess, out var validGuess))
      {
        return "please enter a guess of four valid colours";

      }
      var responseArray = Check(validGuess);
      return String.Join(", ", responseArray);
    }

    // public static ResponseColours[] RandomResponseArray(ResponseColours[] responseColours)
    // {
    //   var rng = new System.Random();
    //   int minValue = 0;
    //   int maxValue = responseColours.Length;

    //   var shuffledResponseColours = new ResponseColours[responseColours.Length];

    //   for (var i = 0; i < responseColours.Length; ++i)
    //   {
    //     shuffledResponseColours[i] = (ResponseColours)rng.Next(minValue, maxValue + 1);


    //   }
    //   return shuffledResponseColours;
    // }





  }
}


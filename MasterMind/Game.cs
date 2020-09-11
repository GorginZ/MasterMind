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

    public static Colours[] FiftyFiftyFixedCodeFactory()
    {
      var code = new[] { Colours.Yellow, Colours.Yellow, Colours.Red, Colours.Red };

      return code;
    }

    public static Colours[] DuplicateFixedCodeFactory()
    {
      var code = new[] { Colours.Red, Colours.Green, Colours.Red, Colours.Purple };
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

    public bool TryParseGuess(string guess, out List<Colours> validGuess)
    {
      validGuess = null;

      var guessArr = guess.Split(", ");
      if (guessArr.Length != 4)
      {
        return false;
      }

      var parsedColours = new List<Colours>();
      for (int i = 0; i < guessArr.Length; i++)
      {
        if (Enum.TryParse(guessArr[i], out Colours colour))
        {
          parsedColours.Add(colour);
        }
        else
        {
          return false;
        }
      }
      validGuess = parsedColours;
      return true;
    }

    // public ResponseColours[] CheckAndReturnClueArray(Colours[] guess)
    // {
    //   var intersectCodeColours = Code.Intersect(guess);
    //   var responseColours = new List<ResponseColours>();
    //   foreach (Colours element in intersectCodeColours)
    //   {
    //     responseColours.Add(ResponseColours.White);
    //   }
    //   for (int i = 0; i < Code.Length; i++)
    //   {
    //     if (guess[i] == Code[i])
    //     {
    //       responseColours.Remove(ResponseColours.White);
    //       responseColours.Add(ResponseColours.Black);
    //     }
    //   }
    //   return responseColours.ToArray();
    // }

    // public ResponseColours[] CheckAndReturnClueArray(Colours[] guess)
    // {
    //   var responseColours = new List<ResponseColours>();

    //   for (int i = 0; i < Code.Length; i++)
    //   {

    //     for (int j = 0; j < Code.Length; j++)
    //     {
    //        if (guess[i] == Code[i] && responseColours.Count < 4)
    //     {
    //       responseColours.Add(ResponseColours.Black);
    //       continue;
    //     }

    //       else if (guess[i] == Code[j] && responseColours.Count < 4)
    //       {
    //         responseColours.Add(ResponseColours.White);
    //       }
    //     }
    //   }
    //   return responseColours.ToArray();

    // }

    // public ResponseColours[] CheckAndReturnClueArray(List<Colours> guess)
    // {
    //   var cList = Code.ToList();
    //   var responseColours = new List<ResponseColours>();
    //   foreach (Colours element in cList)
    //   {
    //     //index of only looks at first occurance?
    //     if (cList.IndexOf(element) == guess.IndexOf(element))
    //     {
    //       responseColours.Add(ResponseColours.Black);
    //       continue;
    //     }
    //     if (guess.Contains(element))
    //     {
    //       responseColours.Add(ResponseColours.White);
    //     }
    //   }
    //   return responseColours.ToArray();
    // }

  public ResponseColours[] CheckAndReturnClueArray(List<Colours> guess)
    {
      var cList = Code.ToList();
      var responseColours = new List<ResponseColours>();
      for (int i = 0; i < Code.Length; i++)
      {
        //index of only looks at first occurance?
        if (cList[i] == guess[i])
        {
          responseColours.Add(ResponseColours.Black);
          cList[i] = Colours.Tick;
          continue;
        }
        if (guess.Contains(cList[i]))
        {
          responseColours.Add(ResponseColours.White);
        }
      }
      return responseColours.ToArray();
    }


    public string ResponseToPlayer(string guess)
    {
      if (!TryParseGuess(guess, out var validGuess))
      {
        return "please enter a guess of four valid colours";

      }
      var responseArray = CheckAndReturnClueArray(validGuess);
      return String.Join(", ", responseArray);
    }
  }
}


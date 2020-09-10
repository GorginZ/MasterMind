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

    public List<ResponseColours> PopulateCluesWithWhite(Colours[] guess)
    {
      var intersectCodeColours = Code.Intersect(guess);
      var responseColours = new List<ResponseColours>();
      foreach (Colours element in intersectCodeColours)
      {
        responseColours.Add(ResponseColours.White);
      }
      return responseColours;
    }

    public ResponseColours[] ReplaceAnyWhiteWithBlackWhereNecessary(Colours[] guess, List<ResponseColours> responseColours)
    {
      for (int i = 0; i < Code.Length; i++)
      {
        if (guess[i] == Code[i])
        {
          responseColours.Remove(ResponseColours.White);
          responseColours.Add(ResponseColours.Black);
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
      var whiteClue = PopulateCluesWithWhite(validGuess);
      var responseArray = ReplaceAnyWhiteWithBlackWhereNecessary(validGuess, whiteClue);
      return String.Join(", ", responseArray);
    }
  }
}


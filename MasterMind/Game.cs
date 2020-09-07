using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
  public class Game
  {

    public Colours[] Code { get; set; }

    public IUserInput UserInput { get; set; }
    

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

  public Colours[] TakeGuess(string guess)
  {
    
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
  // guess: red, red, red, red

// code: blue, green, red, blue


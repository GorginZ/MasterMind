
using System.Collections.Generic;

namespace MasterMind
{
  public class Game
  {
    public Colours[] Code { get; }

    public Game(Colours[] code)
    {
      Code = code;
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

        if (ColourIsInCode(guess[i]))
        {
          responseColours.Add(ResponseColours.White);
        }
      }
      return responseColours.ToArray();
    }

    public bool ColourIsInCode(Colours guessPosition)
    {
      foreach (Colours colour in Code)
      {
        return guessPosition == colour;
      }
      return false;

    }

  }
}

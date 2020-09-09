using System;
using Xunit;
using MasterMind;

namespace MasterMind.Tests
{
  public class UnitTests
  {
    [Fact]
    public void ShouldWinWhenGuessAndCodeEqual()
    {
      var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var guess = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var newGame = new Game{Code = code};
      var actualResponse = newGame.Check(guess);

      var expectedResponse = new[] { ResponseColours.Black, ResponseColours.Black, ResponseColours.Black, ResponseColours.Black };
      Assert.Equal(expectedResponse, actualResponse);
    }
    [Fact]
    public void ShouldReturnWhiteForGuessIncludingCorrectColourValue()
    {
      var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var guess = new[] { Colours.Blue, Colours.Purple, Colours.Purple, Colours.Purple };
      var newGame = new Game();
      newGame.Code = code;
      var actualResponse = newGame.Check(guess);

      var expectedResponse = new[] { ResponseColours.White };
      Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ShouldReturnBlackForGuessIncludingCorrectColourValueAndPosition()
    {
      var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var guess = new[] { Colours.Purple, Colours.Purple, Colours.Green, Colours.Purple };
      var newGame = new Game();
      newGame.Code = code;
      var actualResponse = newGame.Check(guess);

      var expectedResponse = new[] { ResponseColours.Black };
      Assert.Equal(expectedResponse, actualResponse);
    }


    [Fact]
    public void ShouldProduceShuffledCode()
    {
      var gameOne = new Game();
      var gameTwo = new Game();

      var codeOne = gameOne.Code;
      var codeTwo = gameTwo.Code;

      Assert.NotEqual(codeOne, codeTwo);
    }
[Fact]
public void ShouldProduceErrorIfInvalidColourInGuess()
{
  var guessInput = "purple, orange, pink, purple";
  var game = new Game();


  var expected = "please enter a guess of four valid colours";

  Assert.Equal(expected, game.ResponseToPlayer(guessInput));



}
        [Fact]
    public void ShouldReturnShuffledResponseArray()
    {
  // clue array of white and black should be in no particular order
   //Red Blue Green Yellow
      var guess = new[] { Colours.Blue, Colours.Purple, Colours.Green, Colours.Yellow };
      var newGame = new Game(Game.FixedCodeFactory);
      // newGame.Code = code;
      var actualResponse = newGame.Check(guess);

      var expectedResponse = new[] { ResponseColours.White, ResponseColours.Black, ResponseColours.Black };
      Assert.NotEqual(expectedResponse, actualResponse);
    }

    [Fact]
    public void EachColourInCodeShouldOnlyBeCheckedOnce()
    {
            var guess = new[] { Colours.Red, Colours.Red, Colours.Red, Colours.Red };
      var newGame = new Game(Game.FixedCodeFactory);
      // newGame.Code = code;
      var actualResponse = newGame.Check(guess);

      var expectedResponse = new[] { ResponseColours.Black };
      Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void CanParseGuess()
    {
      var guess = "Blue, Purple, Green, Yellow";
      var newGame = new Game(Game.FixedCodeFactory);
      newGame.TryParseGuess(guess, out var validGuess);
      var expectedValidGuess = new[] {Colours.Blue, Colours.Purple, Colours.Green, Colours.Yellow};
      Assert.Equal(expectedValidGuess, validGuess);
    }
  }

  
}
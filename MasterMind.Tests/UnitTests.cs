using System;
using Xunit;
using MasterMind;
using System.Collections.Generic;

namespace MasterMind.Tests
{
  public class UnitTests
  {
    [Fact]
    public void ShouldWinWhenGuessAndCodeEqual()
    {
      var guess = new List<Colours> { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var newGame = new Game(Game.FixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new[] { ResponseColours.Black, ResponseColours.Black, ResponseColours.Black, ResponseColours.Black };
      Assert.Equal(expectedResponse, actualResponse);
    }
    [Fact]
    public void ShouldReturnWhiteForGuessIncludingCorrectColourValue()
    {
      var guess = new List<Colours> { Colours.Blue, Colours.Purple, Colours.Purple, Colours.Purple };
      var newGame = new Game(Game.FixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new[] { ResponseColours.White };
      Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ShouldReturnBlackForGuessIncludingCorrectColourValueAndPosition()
    {
      var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var guess = new List<Colours> { Colours.Purple, Colours.Purple, Colours.Green, Colours.Purple };
      var newGame = new Game();
      newGame.Code = code;
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
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
      var guess = new List<Colours>  { Colours.Blue, Colours.Purple, Colours.Green, Colours.Yellow };
      var newGame = new Game(Game.FixedCodeFactory);
      // newGame.Code = code;
      var actualResponse = newGame.CheckAndReturnClueArray(guess);

      var expectedResponse = new[] { ResponseColours.White, ResponseColours.Black, ResponseColours.Black };
      Assert.NotEqual(expectedResponse, actualResponse);
    }

    [Fact]
    public void EachColourInCodeShouldOnlyBeCheckedOnce()
    {
      var guess = new List<Colours>  { Colours.Red, Colours.Red, Colours.Red, Colours.Red };
      var newGame = new Game(Game.FixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new[] { ResponseColours.Black };
      Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void CanHandleFiftyFiftySplitGuess()
    {
      var guess = new List<Colours> { Colours.Red, Colours.Red, Colours.Yellow, Colours.Yellow };
      var newGame = new Game(Game.FiftyFiftyFixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new[] { ResponseColours.White, ResponseColours.White, ResponseColours.White, ResponseColours.White };
      Assert.Equal(expectedResponse, actualResponse);
    }

[Fact]
    public void CanHandleDuplicatesInCodeAndGuess()
    {
                  // factory is: { Colours.Red, Colours.Green, Colours.Red, Colours.Purple };
  var guess = new List<Colours> { Colours.Purple, Colours.Red, Colours.Red, Colours.Yellow };
      var newGame = new Game(Game.DuplicateFixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new[] { ResponseColours.White, ResponseColours.White, ResponseColours.Black };
      Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void CanParseGuess()
    {
      var guess = "Blue, Purple, Green, Yellow";
      var newGame = new Game(Game.FixedCodeFactory);
      newGame.TryParseGuess(guess, out var validGuess);
      var expectedValidGuess = new[] { Colours.Blue, Colours.Purple, Colours.Green, Colours.Yellow };
      Assert.Equal(expectedValidGuess, validGuess);
    }
  }


}
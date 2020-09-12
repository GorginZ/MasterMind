using System;
using Xunit;
using MasterMind;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Tests
{
  public class UnitTests
  {

        [Fact]
    public void GameShouldHaveShuffledCode()
    {
      var gameOne = new Game();
      var gameTwo = new Game();

      var codeOne = gameOne.Code;
      var codeTwo = gameTwo.Code;

      Assert.NotEqual(codeOne, codeTwo);
    }

    public static int CountOccurenceOfResponseColour(List<ResponseColours> actualResponse, ResponseColours responseColourToFind)
    {
      return ((from responseColours in actualResponse where responseColours.Equals(responseColourToFind) select responseColours).Count());
    }
    [Fact]
    public void ResponseShouldBeAllBlackOnWin()
    {
      var guess = new List<Colours> { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var newGame = new Game(Game.FixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new List<ResponseColours> { ResponseColours.Black, ResponseColours.Black, ResponseColours.Black, ResponseColours.Black };

      var actualWhiteCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.White);
      var actualBlackCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.Black);
      var expectedWhiteCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.White);
      var expectedBlackCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.Black);
      Assert.Equal(expectedWhiteCount, actualWhiteCount);
      Assert.Equal(expectedBlackCount, actualBlackCount);
    }
    [Fact]
    public void ShouldReturnOneWhiteForGuessIncludingOneCorrectColourValue()
    {
      var guess = new List<Colours> { Colours.Blue, Colours.Purple, Colours.Purple, Colours.Purple };
      var newGame = new Game(Game.FixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new List<ResponseColours> { ResponseColours.White };

      var actualWhiteCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.White);
      var actualBlackCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.Black);

      var expectedWhiteCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.White);
      var expectedBlackCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.Black);
      Assert.Equal(expectedWhiteCount, actualWhiteCount);
      Assert.Equal(expectedBlackCount, actualBlackCount);
    }

    [Fact]
    public void ShouldReturnOneBlackForGuessIncludingOneCorrectColourValueAndPosition()
    {
      var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var guess = new List<Colours> { Colours.Purple, Colours.Purple, Colours.Green, Colours.Purple };
      var newGame = new Game();
      newGame.Code = code;
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new List<ResponseColours> { ResponseColours.Black };

      var actualWhiteCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.White);
      var actualBlackCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.Black);

      var expectedWhiteCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.White);
      var expectedBlackCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.Black);
      Assert.Equal(expectedWhiteCount, actualWhiteCount);
      Assert.Equal(expectedBlackCount, actualBlackCount);
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
    public void EachColourInCodeShouldOnlyBeCheckedOnce()
    {
      var guess = new List<Colours> { Colours.Red, Colours.Red, Colours.Red, Colours.Red };
      var newGame = new Game(Game.FixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new List<ResponseColours> { ResponseColours.Black };

      var actualWhiteCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.White);
      var actualBlackCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.Black);
      var expectedWhiteCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.White);
      var expectedBlackCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.Black);
      Assert.Equal(expectedWhiteCount, actualWhiteCount);
      Assert.Equal(expectedBlackCount, actualBlackCount);
    }

    [Fact]
    public void CanHandleFiftyFiftySplitGuess()
    {
      var guess = new List<Colours> { Colours.Red, Colours.Red, Colours.Yellow, Colours.Yellow };
      var newGame = new Game(Game.FiftyFiftyFixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new List<ResponseColours> { ResponseColours.White, ResponseColours.White, ResponseColours.White, ResponseColours.White };

      var actualWhiteCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.White);
      var actualBlackCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.Black);
      var expectedWhiteCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.White);
      var expectedBlackCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.Black);
      Assert.Equal(expectedWhiteCount, actualWhiteCount);
      Assert.Equal(expectedBlackCount, actualBlackCount);
    }

    [Fact]
    public void CanHandleDuplicatesInCodeAndGuess()
    {
      // factory is: { Colours.Red, Colours.Green, Colours.Red, Colours.Purple };
      var guess = new List<Colours> { Colours.Purple, Colours.Red, Colours.Red, Colours.Yellow };
      var newGame = new Game(Game.DuplicateFixedCodeFactory);
      var actualResponse = newGame.CheckAndReturnClueArray(guess);
      var expectedResponse = new List<ResponseColours> { ResponseColours.White, ResponseColours.Black, ResponseColours.White };

      var actualWhiteCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.White);
      var actualBlackCount = CountOccurenceOfResponseColour(actualResponse, ResponseColours.Black);
      var expectedWhiteCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.White);
      var expectedBlackCount = CountOccurenceOfResponseColour(expectedResponse, ResponseColours.Black);
      Assert.Equal(expectedWhiteCount, actualWhiteCount);
      Assert.Equal(expectedBlackCount, actualBlackCount);
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

        [Fact]
    public void ShouldReturnShuffledResponseArrayOfClues()
    {
    
      var gameOne = new Game(Game.FixedCodeFactory);
      var gameTwo = new Game(Game.FixedCodeFactory);

      var guessOne = new List<Colours> { Colours.Blue, Colours.Purple, Colours.Green, Colours.Yellow };
      var guessTwo = new List<Colours> { Colours.Blue, Colours.Purple, Colours.Green, Colours.Yellow };

      var responseOne = gameOne.CheckAndReturnClueArray(guessOne);
      var responseTwo = gameTwo.CheckAndReturnClueArray(guessTwo);

      Assert.NotEqual(responseOne, responseTwo);
    }
  }


}
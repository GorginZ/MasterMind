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
    var newGame = new Game(code);
    var actualResponse = newGame.Check(guess);
    
    var expectedResponse = new []{ResponseColours.Black, ResponseColours.Black, ResponseColours.Black, ResponseColours.Black};
    Assert.Equal(expectedResponse, actualResponse);
    }
[Fact]
    public void ShouldReturnWhiteForGuessIncludingCorrectColourValue() 
    {
            var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var guess = new[] { Colours.Blue, Colours.Purple, Colours.Purple, Colours.Purple };
    var newGame = new Game(code);
    var actualResponse = newGame.Check(guess);
    
    var expectedResponse = new []{ResponseColours.White};
    Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public void ShouldReturnBlackForGuessIncludingCorrectColourValueAndPosition() 
    {
            var code = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
      var guess = new[] { Colours.Purple, Colours.Purple, Colours.Green, Colours.Purple };
    var newGame = new Game(code);
    var actualResponse = newGame.Check(guess);
    
    var expectedResponse = new []{ResponseColours.Black};
    Assert.Equal(expectedResponse, actualResponse);
    }

  }
}
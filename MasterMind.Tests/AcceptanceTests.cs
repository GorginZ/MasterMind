using System;
using Xunit;
using MasterMind;

namespace MasterMind.Tests
{
    public class AcceptanceTest
    {

//       If the Mastermind selected the following colours

// Then the array you are trying to solve is ["Red", "Blue", "Green", "Yellow"]

// So you guess with

// ["Red", "Orange", "Yellow", "Orange"]

// Your method would look like this.

// function mastermind(game){ answer = game.check(["Red", "Orange", "Yellow", "Orange"]); } The element 0 => Red is at the correct index so Black is added to the return array. Element 2 => Yellow is in the array but at the wrong index possition so White is added to the return array.

// The Mastermind would then return ["Black", "White"] (But not necessarily in that order as the return array is shuffled my the Mastermind).

// Keep guessing until you pass the correct solution which will pass the Kata.
        [Fact]
        public void Acceptance()
        {
        var code = new []{Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow};
        var guess = new []{Colours.Red, Colours.Orange, Colours.Yellow, Colours.Orange};
        var newGame = new Game{Code = code};
        var actualResponse = newGame.Check(guess);
        var expectedResponse = new []{ResponseColours.Black, ResponseColours.White};
        Assert.Equal(expectedResponse, actualResponse);
        }
    }
}

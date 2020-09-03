using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var newGame = new Game(new []{Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue});
        }
    }
}
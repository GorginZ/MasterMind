namespace MasterMind
{
    public interface IUserInput
    {
      //a Read() exists in ConsoleUserInput.cs, likewise in another userinput class, say for a webapp, would have a Read()
      //this is the animal sound part, oink, moo but all 'sounds'
        string Read();
    }
}
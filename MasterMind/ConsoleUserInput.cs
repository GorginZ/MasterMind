using System.ComponentModel.DataAnnotations;
using System;

namespace MasterMind
{
    public class ConsoleUserInput : IUserInput
    {
      public string Read() {
        return Console.ReadLine();
      }
     
    }
}
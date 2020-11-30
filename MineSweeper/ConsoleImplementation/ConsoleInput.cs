using System;
using System.ComponentModel.DataAnnotations;

namespace MineSweeper.ConsoleImplementation
{
  public class ConsoleInput : IUserInput
  {
    public string ReadInput(string askThis)
    {
      Console.WriteLine(askThis);
      return Console.ReadLine();
    }
  }
}
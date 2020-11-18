using System;
using System.Text;

namespace MineSweeper.ConsoleImplementation
{
  public class ConsoleOutput : IOutPut
  {
    public void DisplayField(string field)
    {
      Console.WriteLine(field);
    }
  }
}
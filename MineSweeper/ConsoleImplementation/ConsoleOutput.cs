using System;
using System.Text;

namespace MineSweeper.ConsoleImplementation
{
  public class ConsoleOutput : IOutPut
  {
    public void Write(string printThis)
    {
      Console.WriteLine(printThis);
    }
  }
}
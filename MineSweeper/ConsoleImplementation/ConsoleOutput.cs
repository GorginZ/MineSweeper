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
    public void Render(string field)
    {
      Console.Clear();
      this.Write("\n\n\n");
      this.Write("-----MINESWEEPER-----");
      this.Write(field);
      this.Write("---------------------");
    }
  }
}
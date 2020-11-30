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
      var heading = "---------MINESWEEPER---------\n";
      var footer = "\n-----------------------------";
      var sb = new StringBuilder();
      sb.Append(heading);
      sb.Append(field);
      sb.Append(footer);
      this.Write(sb.ToString());
    }
  }
}
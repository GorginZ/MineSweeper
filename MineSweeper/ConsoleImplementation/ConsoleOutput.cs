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
      var heading = "-----MINESWEEPER-----";
      var footer = "---------------------";
      this.Write("\n\n\n");
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (heading.Length / 2)) + "}", heading));
      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth) + (heading.Length)) + "}", field));

      Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (heading.Length / 2)) + "}", footer));

    }
  }
}
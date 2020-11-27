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
    public int SquareDimensions;
    public RowColumn SquareSelection;
    public void Read() => Console.ReadLine();

    public void SetRange()
    {
      PromptDimensions();
    }
    public void PromptDimensions()
    {
      Console.WriteLine("Enter dimensions you want for your field (range 3-50)");
      var userInput = Console.ReadLine();
      do
      {
        CheckInput(userInput);
        if (CheckInput(userInput))
        {
          SquareDimensions = int.Parse(userInput);
          return;
        }
      } while (!CheckInput(userInput));
    }

    public static bool CheckInput(string input)
    {
      int.TryParse(input, out int number);
      return number >= 3 && number < 30;
    }
    public RowColumn ParseInputToRowColumn()
    {
      var input = Console.ReadLine();
      var chars = input.Split(" ", StringSplitOptions.None);
      return new RowColumn(int.Parse(chars[0]), int.Parse(chars[1]));
    }
  }
}
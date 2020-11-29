using System;
using System.ComponentModel.DataAnnotations;

namespace MineSweeper.ConsoleImplementation
{
  public class ConsoleInput : IUserInput
  {
    public void Read() => Console.ReadLine();
    public int GetValidDimensions()
    {
      int squareDimensions = 0;
      string userInput;
      do
      {
        Console.WriteLine("Enter dimensions you want for your field (bw 3-30)");
        userInput = Console.ReadLine();
        try
        {
          IsValidDimension(userInput);
          squareDimensions = int.Parse(userInput);
        }
        catch (FormatException)
        {
          Console.WriteLine("Please enter a number");
        }
      } while (!IsValidDimension(userInput));
      return squareDimensions;
    }
    public static bool IsValidDimension(string input)
    {
      int.TryParse(input, out int number);
      return number >= 3 && number < 30;
    }
    public RowColumn ParseInputToRowColumn()
    {
      {
        var input = Console.ReadLine();
        var chars = input.Split(" ", StringSplitOptions.None);
        return new RowColumn(int.Parse(chars[0]), int.Parse(chars[1]));
      }
    }
  }
}
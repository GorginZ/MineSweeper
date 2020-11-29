using System;
using System.ComponentModel.DataAnnotations;

namespace MineSweeper.ConsoleImplementation
{
  public class ConsoleInput : IUserInput
  {
    //does this need to be a property?
    public int SquareDimensions;
    public RowColumn SquareSelection;
    public void Read() => Console.ReadLine();

    public string ReadInput(string askThis)
    {
      Console.WriteLine(askThis);
      return Console.ReadLine();
    }
    public void GetValidDimensions()
    {
      var userInput = "";
      do
      {
        Console.WriteLine("Enter dimensions you want for your field (bw 3-30)");
        userInput = Console.ReadLine();
        try
        {
          IsValidDimension(userInput);
          SquareDimensions = int.Parse(userInput);
        }
        catch (FormatException)
        {
          Console.WriteLine("Please enter a number");
        }
      } while (!IsValidDimension(userInput));
    }
    public static bool IsValidDimension(string input)
    {
      int.TryParse(input, out int number);
      return number >= 3 && number < 30;
    }
    public void GetValidSquareSelection()
    {
      do
      {
        try
        {
          ParseInputToRowColumn();
        }
        catch (IndexOutOfRangeException)
        { }
      }
      while ();
    }
    public RowColumn ParseInputToRowColumn()
    {
      while(!IsValidRowColInput(chars))
      {
        var input = Console.ReadLine();
        var chars = input.Split(" ", StringSplitOptions.None);
        try
        {
          return new RowColumn(int.Parse(chars[0]), int.Parse(chars[1]));
        }
        catch (IndexOutOfRangeException)
        {
        }
      }
    }
    public static bool IsValidRowColInput(string[] chars) => chars.Length == 2;
  }
}
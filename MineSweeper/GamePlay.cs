using System;
using System.Threading;
namespace MineSweeper
{
  public class GamePlay
  {
    private IOutPut _outPut;
    private IUserInput _inPut;
    public GamePlay(IOutPut outPut, IUserInput userInput)
    {
      _inPut = userInput;
      _outPut = outPut;
    }

    public void Run()
    {
      var dimensions = GetValidDimensions();
      var minePositioning = new RandomMinePositions(dimensions, dimensions, dimensions);
      var mineField = new MineField(dimensions, dimensions, minePositioning);
      var game = new Game(mineField);
      do
      {
        try
        {
          _outPut.Write(game.GetCurrentField());
          game.HandleSelectedSquare(ParseInputToRowColumn());
        }
        catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
        {
        }
      } while (!game.HasWon() && !game.PlayerLost);
      _outPut.Write(game.GetCurrentField());
      var endMessage = game.HasWon() ? "Well done" : "You lost";
      _outPut.Write(endMessage);
    }

    public int GetValidDimensions()
    {
      int squareDimensions = 0;
      string userInput;
      do
      {
        userInput = _inPut.ReadInput("Enter dimensions you want for your field (bw 3 - 30");
        try
        {
          IsValidDimension(userInput);
          squareDimensions = int.Parse(userInput);
        }
        catch (FormatException)
        {
          _outPut.Write("Please enter a number");
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
        var input = _inPut.ReadInput("enter a Square to Hit eg: '0 0'");
        var chars = input.Split(" ", StringSplitOptions.None);
        return new RowColumn(int.Parse(chars[0]), int.Parse(chars[1]));
      }
    }
  }
}
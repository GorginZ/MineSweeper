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
      var rowDimensions = GetValidDimensions();
      var colDimensions = GetValidDimensions();
      var noOfMines = GetNumberOfMines(rowDimensions, colDimensions);
      var minePositioning = new RandomMinePositions(rowDimensions, colDimensions, noOfMines);
      var mineField = new MineField(rowDimensions, colDimensions, minePositioning);
      var game = new Game(mineField);
      //handle first hit and re-arrange upon loss
      game.HandleFirstHit(ParseInputToRowColumn());
      _outPut.Render(game.GetCurrentField());

      do
      {
        try
        {
          _outPut.Render(game.GetCurrentField());
          ProcessTurn(game);
        }
        catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
        {
        }
      } while (!game.HasWon() && !game.PlayerLost);
      _outPut.Render(game.GetCurrentField());
      var endMessage = game.HasWon() ? "Well done" : "You lost";
      _outPut.Write(endMessage);
    }

    public void ProcessTurn(Game game)
    {
      var action = _inPut.ReadInput("'H' to hit 'F' to Flag");
      if (action == "H")
      {
        game.HitSelectedSquare(ParseInputToRowColumn());
      }
      if (action == "F")
      {
        game.FlagSquare(ParseInputToRowColumn());
      }
    }

    public int GetValidDimensions()
    {
      int fieldDimension = 0;
      string userInput;
      do
      {
        userInput = _inPut.ReadInput("Enter a value for field dimensions (bw 3 - 30, recommended: 15 rows 30 columns )");
        try
        {
          IsValidDimension(userInput);
          fieldDimension = int.Parse(userInput);
        }
        catch (FormatException)
        {
          _outPut.Write("Please enter a number");
        }
      } while (!IsValidDimension(userInput));
      return fieldDimension;
    }
    public static bool IsValidDimension(string input)
    {
      int.TryParse(input, out int number);
      return number >= 3 && number < 30;
    }
    public int GetNumberOfMines(int rowDimensions, int colDimensions)
    {
      bool parsed;
      int result;
      do
      {
        var userInput = _inPut.ReadInput("How Many mines?");
        parsed = int.TryParse(userInput, out int outInt);
        result = outInt;
      }
      while (!parsed || result > rowDimensions * colDimensions);
      return result;
    }
    public RowColumn ParseInputToRowColumn()
    {
      {
        var input = _inPut.ReadInput("enter a row column eg: '0 0'");
        var chars = input.Split(" ", StringSplitOptions.None);
        return new RowColumn(int.Parse(chars[0]), int.Parse(chars[1]));
      }
    }
  }
}
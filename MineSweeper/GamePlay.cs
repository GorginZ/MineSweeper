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
      var rowDimensions = GetValidDimensions("row");
      var colDimensions = GetValidDimensions("column");
      var noOfMines = GetNumberOfMines(rowDimensions, colDimensions);
      var minePositioning = new RandomMinePositions(rowDimensions, colDimensions, noOfMines);
      var mineField = new MineField(rowDimensions, colDimensions, minePositioning);
      var game = new Game(mineField);

      game.HandleFirstHit(ParseInputToRowColumn(rowDimensions, colDimensions));
      _outPut.Render(game.GetCurrentField());

      do
      {
        _outPut.Render(game.GetCurrentField());
        ProcessTurn(game, rowDimensions, colDimensions);
      } while (!game.HasWon() && !game.HasPlayerLost);
      _outPut.Render(game.GetCurrentField());
      var endMessage = game.HasWon() ? "Well done" : "You Hit A Mine";
      _outPut.Write(endMessage);
    }

    public int GetValidDimensions(string dimension)
    {
      int fieldDimension = 0;
      string userInput;
      do
      {
        userInput = _inPut.ReadInput($"enter a value for {dimension} dimension (bw 3 - 30, recommended: 15 rows 30 columns )");
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
      return number >= 3 && number <= 30;
    }

    public void ProcessTurn(Game game, int rowDimension, int colDimension)
    {
      var action = _inPut.ReadInput("'H' to hit 'F' to Flag").ToUpper();
      if (action == "H")
      {
        game.HitSelectedSquare(ParseInputToRowColumn(rowDimension, colDimension));
      }
      if (action == "F")
      {
        game.FlagSquare(ParseInputToRowColumn(rowDimension, colDimension));
      }
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
      while (!parsed || result > (rowDimensions * colDimensions) - 1);
      return result;
    }
    public RowColumn ParseInputToRowColumn(int rowDimensions, int columnDimensions)
    {
      while (true)
      {
        var input = _inPut.ReadInput("enter a row column eg: '0 0'");
        var chars = input.Split(" ", StringSplitOptions.None);
        if (chars.Length == 2)
        {
          var isParsedRow = int.TryParse(chars[0], out int row);
          var isParsedCol = int.TryParse(chars[1], out int col);
          if (isParsedRow && isParsedCol && row < rowDimensions && col < columnDimensions)
          {
            return new RowColumn(int.Parse(chars[0]), int.Parse(chars[1]));
          }
        }
      }
    }
  }
}
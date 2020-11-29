using System;
using System.Threading;
namespace MineSweeper
{
  public static class GamePlay
  {
    public static void Run(IOutPut outPut, IUserInput userInput, MineField mineField)
    {
      var game = new Game(mineField);
      do
      {
        try
        {
          ProcessTurn(outPut, userInput, game);
        }
        catch (Exception ex) when (
    ex is IndexOutOfRangeException
    || ex is FormatException
)
        {
        }
      } while (!game.HasWon() && !game.PlayerLost);
      outPut.Write(game.GetCurrentField());
      var endMessage = game.HasWon() ? "Well done" : "You lost";
      outPut.Write(endMessage);
    }
    public static void ProcessTurn(IOutPut outPut, IUserInput userInput, Game game)
    {
      outPut.Write("Enter a row column index to 'hit'");
      outPut.Write(game.GetCurrentField());
      game.HandleSelectedSquare(userInput.ParseInputToRowColumn());
    }
  }
}
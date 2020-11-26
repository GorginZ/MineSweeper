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
        outPut.Write("Enter a row column index to 'hit'");
        outPut.Write(game.GetCurrentField());
        game.HandleSelectedSquare(userInput.ParseInputToRowColumn());

      } while (!game.HasWon() && !game.Haslost);
      outPut.Write(game.GetCurrentField());
      var endMessage = game.HasWon() ? "Well done" : "You lost";
      outPut.Write(endMessage);
    }
  }
}
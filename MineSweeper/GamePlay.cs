using System;
using System.Threading;
namespace MineSweeper
{
  public static class GamePlay
  {
    public static void Run(IOutPut outPut, IUserInput userInput, MineField mineField)
    {
      var game = new Game(mineField);
      outPut.Write("Enter a row column index to 'hit'");
      outPut.Write(game.GetCurrentField());
      // game.ProcessFirstHit(userInput.ParseInputToRowColumn());
      game.ProcessFirstHit(new RowColumn(0,0));
      
      outPut.Write(game.GetCurrentField());
      do
      {
        outPut.Write("Enter a row column index to 'hit'");
        outPut.Write(game.GetCurrentField());
        game.HandleSelectedSquare(userInput.ParseInputToRowColumn());
      } while (!game.HasWon() || !game.Haslost);
      var endMessage = game.HasWon() ? "Well done" : "You lost";
      outPut.Write(endMessage);
    }
  }
}
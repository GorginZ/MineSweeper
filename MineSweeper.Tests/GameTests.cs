using System;
using Xunit;

namespace MineSweeper.Tests
{
  public class GameTests
  {
    [Fact]
    public void GameHasAFieldOfCellContentsSafeAndMine()
    {
      //not a very meaningful test coz random revisit
      var game = new Game(1, 2, 1);
      var field = game.GetField();
      Assert.True(field[0,0] == CellContents.Safe || field[0,0] == CellContents.Mine);
    }
    [Fact]
    public void CanInitializeFieldWithRowColumnDimensionsAndCustomNumberOfMines()
    {
      var game = new Game(20, 30, 20);
      var mineField = game.GetField();
      int actualNumberOfMinesInField = 0;

      for (int i = 0; i < 20; i++)
      {
        for (int j = 0; j < 30; j++)
        {
          if (mineField[i, j] == CellContents.Mine)
          {
            actualNumberOfMinesInField++;
          }
        }
      }
      Assert.Equal(20, actualNumberOfMinesInField);
    }
   public void PlayerDoesntLooseFirstSelection()
   {

   } 

  }
}
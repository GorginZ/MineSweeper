using System.Collections.Generic;
using Xunit;

namespace MineSweeper.Tests
{
  public class IntegrationTests
  {
    [Fact]
    public void SquareHintValuesAreAccuratelyCalculated()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = " 1...\n"
                        + " 211.\n"
                        + "   1.\n"
                        + "   21\n"
                        + "     \n";
      game.HitSelectedSquare(new RowColumn(0, 4));
      Assert.Equal(expectedField, game.GetCurrentField());
    }

    [Fact]
    public void CantLoseOnFirstHitCalculatesCluesAgainAppropriately()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(1,0), new RowColumn(1,1) });
      var mineField = new MineField(3, 3, minePositioning);
      var game = new Game(mineField);
      game.HandleFirstHit(new RowColumn(0, 0));
      var expectedField = "3  \n"
                        + "   \n"
                        + "   \n";
      Assert.Equal(expectedField, game.GetCurrentField());
    }
    [Fact]
    public void StilHasSameNumberOfMinesAfterFirstHitRearrange()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      int numberOfMinesBeforeHit = mineField.MineCount;
      game.HandleFirstHit(new RowColumn(2, 2));
      int numberOfMinesAfterHit = mineField.MineCount;
      Assert.Equal(numberOfMinesBeforeHit, numberOfMinesAfterHit);
    }
    // private int NumberOfMinesInField(int rows, int columns, Square[,] field)
    // {
    //   int actualNumberOfMinesInField = 0;
    //   for (int i = 0; i < rows; i++)
    //   {
    //     for (int j = 0; j < columns; j++)
    //     {
    //       if (field[i, j].SquareType == SquareType.Mine)
    //       {
    //         actualNumberOfMinesInField++;
    //       }
    //     }
    //   }
    //   return actualNumberOfMinesInField;
    // }

  }
}
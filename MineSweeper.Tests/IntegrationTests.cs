using System.Collections.Generic;
using Xunit;

namespace MineSweeper.Tests
{
  public class IntegrationTests
  {
    [Fact]
    public void CantLoseOnFirstClickMovesMineToTopLeftReCalculatesSquareHints()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      game.ProcessFirstHit(new RowColumn(2, 2));
      var expectedField = " 1...\n"
                        + "11...\n"
                        + ".....\n"
                        + "...11\n"
                        + "...1 \n";
      Assert.Equal(expectedField, game.FieldAsString());
    }
    [Fact]
    public void StilHasSameNumberOfMinesAfterFirstHitRearrange()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      int numberOfMinesBeforeHit = NumberOfMinesInField(5, 5, mineField.Field);
      game.ProcessFirstHit(new RowColumn(2, 2));
      int numberOfMinesAfterHit = NumberOfMinesInField(5, 5, mineField.Field);
      Assert.Equal(numberOfMinesBeforeHit, numberOfMinesAfterHit);
    }
    private int NumberOfMinesInField(int rows, int columns, Square[,] field)
    {
      int actualNumberOfMinesInField = 0;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < columns; j++)
        {
          if (field[i, j].SquareType == SquareType.Mine)
          {
            actualNumberOfMinesInField++;
          }
        }
      }
      return actualNumberOfMinesInField;
    }
  }
}
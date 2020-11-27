using System;
using System.Collections.Generic;
using Xunit;

namespace MineSweeper.Tests
{
  public class MineFieldTests
  {
    [Fact]
    public void MineFieldIsOfSpecifiedDimensions()
    {
      var minePlacement = new RandomMinePositions(1, 2, 1);
      var field = new MineField(1, 2, minePlacement);
      Assert.True(field.RowDimension == 1);
      Assert.True(field.ColumnDimension == 2);
    }

    [Fact]
    public void CanMakeSafeField()
    {
      var minePlacement = new RandomMinePositions(5, 5, 0);
      var field = new MineField(5, 5, minePlacement);
      Assert.Equal(0, field.MineCount);
    }

    [Fact]
    public void CanAlwaysAllocatePositionsForFullNumberOfMines()
    {
      var minePlacement = new RandomMinePositions(5,5, 25);
      var field = new MineField(5, 5, minePlacement);
      Assert.Equal(25, field.MineCount);
    }
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
      game.HandleSelectedSquare(new RowColumn(0, 4));
      Assert.Equal(expectedField, game.GetCurrentField());
    }
  }
}
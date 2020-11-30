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
      var minePlacement = new RandomMinePositions(2, 2, 1);
      var field = new MineField(2, 2, minePlacement);
      Assert.True(field.RowDimension == 2);
      Assert.True(field.ColumnDimension == 2);
    }
    [Fact]
    public void MineFieldThatReceievesInvalidArgsThrowsArgumentException()
    {
      var minePlacement = new RandomMinePositions(0, 0, 0);
      var ex = Assert.Throws<ArgumentException>(() => new MineField(0, 0, minePlacement));
      Assert.Equal("row and column dimensions are below minimum usable value", ex.Message);
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
      var minePlacement = new RandomMinePositions(5, 5, 25);
      var field = new MineField(5, 5, minePlacement);
      Assert.Equal(25, field.MineCount);
    }
    [Fact]
    public void ThrowsExceptionIfSetMinesHasAnOutOfIndexItem()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(5, 4) });
      var ex = Assert.Throws<ArgumentException>(() => new MineField(3, 3, minePositioning));
      Assert.Equal("Mine list contains elements greater than field array dimensions", ex.Message);
    }
  }
}
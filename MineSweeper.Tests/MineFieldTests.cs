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
      var minePlacement = new RandomMinePositions(1,2,1);
      var field = new MineField(1, 2, minePlacement);
      Assert.True(field.Field.GetLength(0) == 1);
      Assert.True(field.Field.GetLength(1) == 2);
    }

    [Fact]
    public void CanMakeSafeField()
    {
      var minePlacement = new RandomMinePositions(5,5,0);
      var field = new MineField(5, 5, minePlacement);
      var actualNumberOfMinesInField = NumberOfMinesInField(5, 5, field.Field);
      Assert.Equal(0, actualNumberOfMinesInField);
    }

    [Fact]
    public void CanAlwaysAllocatePositionsForFullNumberOfMines()
    {
      var minePlacement = new RandomMinePositions(5,5,25);
      var field = new MineField(5, 5, minePlacement);
      int actualNumberOfMinesInField = NumberOfMinesInField(5, 5, field.Field);

      Assert.Equal(25, actualNumberOfMinesInField);
    }
    [Fact]
    public void SquareHaveCorrectSquareHintValue()
    {
      var minePlacement = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(0, 2), new RowColumn(0, 3), new RowColumn(0, 4), new RowColumn(1, 0), new RowColumn(2, 0), new RowColumn(3, 0), new RowColumn(4, 0), new RowColumn(4, 1), new RowColumn(4, 2), new RowColumn(4, 3), new RowColumn(4, 4), new RowColumn(1, 4), new RowColumn(2, 4), new RowColumn(3, 4) });
      var field = new MineField(5, 5, minePlacement);
      Assert.Equal(5, field.Field[1, 1].SquareHintValue);
      Assert.Equal(3, field.Field[1, 2].SquareHintValue);
      Assert.Equal(5, field.Field[3, 1].SquareHintValue);
      Assert.Equal(0, field.Field[2, 2].SquareHintValue);
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
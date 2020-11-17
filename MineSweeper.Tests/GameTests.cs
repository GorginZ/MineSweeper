using System;
using System.Collections.Generic;
using Xunit;

namespace MineSweeper.Tests
{
  public class GameTests
  {
    [Fact]
    public void MineFieldIsOfSpecifiedDimensions()
    {
      var minePlacement = new RandomMinePlacement();
      var game = new Game(1, 2, 1, minePlacement);
      var field = game.GetField();
      Assert.True(field.GetLength(0) == 1);
      Assert.True(field.GetLength(1) == 2);
    }

    [Fact]
    public void CanMakeSafeField()
    {
      var minePlacement = new RandomMinePlacement();
      var game = new Game(10, 10, 0, minePlacement);
      var mineField = game.GetField();
      var actualNumberOfMinesInField = NumberOfMinesInField(10, 10, mineField);
      Assert.Equal(0, actualNumberOfMinesInField);
    }

    [Fact]
    public void CanInitializeFieldWithCustomNumberOfMines()
    {
      var minePlacement = new RandomMinePlacement();
      var game = new Game(5, 5, 25, minePlacement);
      var mineField = game.GetField();
      int actualNumberOfMinesInField = NumberOfMinesInField(5, 5, mineField);

      Assert.Equal(25, actualNumberOfMinesInField);
    }
    [Fact]
    public void CanCalculateClueForSelectedSquare()
    {
      var minePlacement = new SetMinePlacement(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(0, 1), new RowColumn(0, 2), new RowColumn(0, 3), new RowColumn(0, 4), new RowColumn(1, 0), new RowColumn(2, 0), new RowColumn(3, 0), new RowColumn(4, 0), new RowColumn(4, 1), new RowColumn(4, 2), new RowColumn(4, 3), new RowColumn(4, 4), new RowColumn(1, 4), new RowColumn(2, 4), new RowColumn(3, 4) });
      var hashSetOfMineIndexes = minePlacement.GetMinePositions(5, 5, 25);
      var game = new Game(5, 5, 25, minePlacement);
      var mineField = game.GetField();
Assert.Equal(5, mineField[1,1].SquareValue);
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
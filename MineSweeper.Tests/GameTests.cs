using System;
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
    private int NumberOfMinesInField(int rows, int columns, SquareType[,] field)
    {
      int actualNumberOfMinesInField = 0;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < columns; j++)
        {
          if (field[i, j] == SquareType.Mine)
          {
            actualNumberOfMinesInField++;
          }
        }
      }
      return actualNumberOfMinesInField;
    }


  }
}
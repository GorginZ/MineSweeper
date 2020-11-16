using System;
using Xunit;

namespace MineSweeper.Tests
{
  public class GameTests
  {
    [Fact]
    public void MineFieldCellsAreEitherSafeOrMine()
    {
      var game = new Game(1, 2, 1);
      var field = game.GetField();
      Assert.True(field[0, 0] == CellContents.Safe || field[0, 0] == CellContents.Mine);
      Assert.True(field[0, 1] == CellContents.Safe || field[0, 1] == CellContents.Mine);

    }
    [Fact]
    public void CanMakeSafeField()
    {
      var game = new Game(10, 10, 0);
      var field = game.GetField();
      var actualNumberOfMinesInField = 0;
      for (int i = 0; i < 10; i++)
      {
        for (int j = 0; j < 10 ; j++)
        {
          if (field[i, j] == CellContents.Mine)
          {
            actualNumberOfMinesInField++;
          }
        }

        Assert.Equal(0, actualNumberOfMinesInField);
      }
    }
      [Fact]
      public void CanInitializeFieldWithCustomNumberOfMines()
      {
        var game = new Game(5, 5, 25);
        var mineField = game.GetField();
        int actualNumberOfMinesInField = 0;

        for (int i = 0; i < 5; i++)
        {
          for (int j = 0; j < 5; j++)
          {
            if (mineField[i, j] == CellContents.Mine)
            {
              actualNumberOfMinesInField++;

            }
          }
        }
        Assert.Equal(25, actualNumberOfMinesInField);
      }

    }
  }
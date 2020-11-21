using System.Collections.Generic;
using MineSweeper.ConsoleImplementation;
using Xunit;

namespace MineSweeper.Tests
{
  public class GameTests
  {
    [Fact]
    public void InitialFieldViewRevealsNoSquareData()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = "     \n"
                        + "     \n"
                        + "     \n"
                        + "     \n"
                        + "     \n";
      Assert.Equal(expectedField, game.FieldAsString());
    }
    [Fact]
    public void RevealsAppropriateSquareHintValue()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = "     \n"
                        + "     \n"
                        + "     \n"
                        + "   2 \n"
                        + "     \n";
      game.ProcessReveal(new RowColumn(3, 3));
      Assert.Equal(expectedField, game.FieldAsString());

    }
    [Fact]
    public void RevealsAppropriateSquareHintValueWhenEmptySquareSelected()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = " 1...\n"
                        + " 211.\n"
                        + "   1.\n"
                        + "   21\n"
                        + "     \n";
      game.ProcessReveal(new RowColumn(0, 4));
      Assert.Equal(expectedField, game.FieldAsString());

    }

    [Fact]
    public void BalloonsCluesOutAppropriately()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0)});
      var mineField = new MineField(5, 5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = " 1...\n"
                        + "11...\n"
                        + ".....\n"
                        + ".....\n"
                        + ".....\n";
      game.ProcessReveal(new RowColumn(0, 4));
      Assert.Equal(expectedField, game.FieldAsString());

    }


    [Fact]
    public void OnLossRevealFullField()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = "*1...\n"
                        + "1211.\n"
                        + ".1*1.\n"
                        + ".1121\n"
                        + "...1*\n";
      Assert.Equal(expectedField, game.FieldAsString());

    }



  }
}
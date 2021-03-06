using System.Collections.Generic;
using Xunit;

namespace MineSweeper.Tests
{
  public class GameTests
  {
    [Fact]
    public void InitialFieldViewRevealsNoSquareData()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = "     \n"
                        + "     \n"
                        + "     \n"
                        + "     \n"
                        + "     \n";
      Assert.Equal(expectedField, game.GetCurrentField());
    }
    [Fact]
    public void RevealsAppropriateSquareHintValue()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = "     \n"
                        + "     \n"
                        + "     \n"
                        + "   2 \n"
                        + "     \n";
      game.HitSelectedSquare(new RowColumn(3, 3));
      Assert.Equal(expectedField, game.GetCurrentField());
    }
    [Fact]
    public void RevealsAppropriateSquareHintValueWhenEmptySquareSelected()
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
    public void BalloonsCluesOutAppropriately()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      var expectedField = " 1...\n"
                        + "11...\n"
                        + ".....\n"
                        + ".....\n"
                        + ".....\n";
      game.HitSelectedSquare(new RowColumn(0, 4));
      Assert.Equal(expectedField, game.GetCurrentField());
    }
    [Fact]
    public void OnLossRevealsAllMinePositionsAndAlreadyUncoveredClues()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0), new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      game.HitSelectedSquare(new RowColumn(0, 4));
      game.HitSelectedSquare(new RowColumn(0, 0));
      var expectedField = "*1...\n"
                        + " 211.\n"
                        + "  *1.\n"
                        + "   21\n"
                        + "    *\n";
      Assert.Equal(expectedField, game.GetCurrentField());
    }
    [Fact]
    public void CanFlagSuspectMine()
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

      game.FlagSquare(new RowColumn(0, 0));
      var expectedFlagField = "F1...\n"
                            + " 211.\n"
                            + "   1.\n"
                            + "   21\n"
                            + "     \n";

      var actualFlagField = game.GetCurrentField();
      Assert.Equal(expectedFlagField, actualFlagField);
    }
    [Fact]
    public void ShouldNotThrowIndexOutOfRange()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(0, 0) });
      var mineField = new MineField(3, 3, minePositioning);
      var game = new Game(mineField);
      game.HitSelectedSquare(new RowColumn(6, 6));
      //write an assert does not throw
    }
  }
}
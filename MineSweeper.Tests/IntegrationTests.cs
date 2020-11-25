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
      Assert.Equal(expectedField, game.GetCurrentField());
    }
    [Fact]
    public void StilHasSameNumberOfMinesAfterFirstHitRearrange()
    {
      var minePositioning = new SetMinePositions(new HashSet<RowColumn> { new RowColumn(2, 2), new RowColumn(4, 4) });
      var mineField = new MineField(5, 5, minePositioning);
      var game = new Game(mineField);
      int numberOfMinesBeforeHit = mineField.MineCount;
      game.ProcessFirstHit(new RowColumn(2, 2));
      int numberOfMinesAfterHit = mineField.MineCount;
      Assert.Equal(numberOfMinesBeforeHit, numberOfMinesAfterHit);
    }
  }
}
using System;
using Xunit;

namespace MineSweeper.Tests
{
  public class RandomMinePositionsTests
  {
    [Fact]
    public void WillThrowArgumentExceptionIfNumberOfMineArgumentExceedsTheRowColumnArguments()
    {
      var minePositions = new RandomMinePositions(3,3,10);
      var ex = Assert.Throws<System.ArgumentException>(() => minePositions.GetMinePositions());

      Assert.Equal("numberOfMines exceeds array dimensions (Parameter '10')", ex.Message);

    }
  }


}
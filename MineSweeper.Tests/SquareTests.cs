using Xunit;

namespace MineSweeper.Tests
{
  public class SquareTests
  {
    [Fact]
    public void CanReprsentSelfAsString()
    {
      Square aMineSquare = new Square(SquareType.Mine);
      Square aSafeSquare = new Square(SquareType.Four);
      string mineSquare = aMineSquare.SquareAsString();
      string safeSquare = aSafeSquare.SquareAsString();
      Assert.Equal("*", mineSquare);
      Assert.Equal("4", safeSquare);
    }
  }
}
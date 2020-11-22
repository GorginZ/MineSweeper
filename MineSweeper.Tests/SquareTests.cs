using Xunit;

namespace MineSweeper.Tests
{
  public class SquareTests
  {
    [Fact]
    public void CanReprsentSelfAsString()
    {
      Square aMineSquare = new Square(SquareType.Mine, 4);
      Square aSafeSquare = new Square(SquareType.Safe, 4);
      string mineSquare = aMineSquare.SquareAsString();
      string safeSquare = aSafeSquare.SquareAsString();
      Assert.Equal("*", mineSquare);
      Assert.Equal("4", safeSquare);
    }
  }
}
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
      aMineSquare.IsRevealed = true;
      aSafeSquare.IsRevealed = true;
      string mineSquare = aMineSquare.SquareAsString();
      string safeSquare = aSafeSquare.SquareAsString();
      Assert.Equal("*", mineSquare);
      Assert.Equal("4", safeSquare);
    }
    [Fact]
    public void ASquareThatIsFlaggedThatIsRevealedCanDisplayItsClueValue()
    {
      var aSafeSquare = new Square(SquareType.Four);
      aSafeSquare.IsRevealed = true;
      aSafeSquare.IsFlagged = true;
      string safeSquare = aSafeSquare.SquareAsString();
      Assert.Equal("4", safeSquare);
    }
    [Fact]
    public void AMineWillBeRepresentedAsMineEvenIfFlaggedWhenItIsRevealed()
    {
      var aMineSquare = new Square(SquareType.Mine);
      aMineSquare.IsRevealed = true;
      aMineSquare.IsFlagged = true;
      string mineSquare = aMineSquare.SquareAsString();
      Assert.Equal("*", mineSquare);
    }
  }
}
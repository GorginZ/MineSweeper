namespace MineSweeper
{
  public class Square
  {
    public SquareType SquareType;
    public bool IsFlagged;
    public bool IsRevealed;
    public Square(SquareType squareType)
    {
      SquareType = squareType;
      IsFlagged = false;
      IsRevealed = false;
    }
    public string SquareAsString()
    {
      var nonRevealedSymbol = this.IsFlagged ? "F" : " ";
      return this.IsRevealed ? this.GetSquareSymbol() : nonRevealedSymbol;
    }
  public string GetSquareSymbol()
    {
      return SquareType switch
      {
        SquareType.Zero => ".",
        SquareType.One => "1",
        SquareType.Two => "2",
        SquareType.Three => "3",
        SquareType.Four => "4",
        SquareType.Five => "5",
        SquareType.Six => "6",
        SquareType.Seven => "7",
        SquareType.Eight => "8",
        SquareType.Mine => "*",
        // _ => " "
      };
    }
  }
}
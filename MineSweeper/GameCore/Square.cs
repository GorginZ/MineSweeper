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
      if (!this.IsRevealed && this.IsFlagged)
      {
        return "F";
      }
      if (this.IsRevealed && this.SquareType != SquareType.Mine)
      {
        var squareSymbol = this.SquareType > 0 ? (this.SquareType.ToString()) : (".");
        return squareSymbol;
      }
      if (!this.IsRevealed)
      {
        return " ";
      }
      else
      {
        return "*";
      }
    }
  }
}
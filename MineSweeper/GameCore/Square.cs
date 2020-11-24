namespace MineSweeper
{
  public class Square
  {
    public SquareType SquareType;
    public int SquareHintValue;
    public bool IsFlagged;
    public bool IsRevealed;
    public Square(SquareType squareType, int hintValue)
    {
      SquareType = squareType;
      SquareHintValue = hintValue;
      IsFlagged = false;
      IsRevealed = false;
    }
    public string SquareAsString()
    {
      if (!this.IsRevealed && this.IsFlagged)
      {
        return "F";
      }
      if (this.IsRevealed && this.SquareType == SquareType.Safe)
      {
        var squareSymbol = this.SquareHintValue > 0 ? (this.SquareHintValue.ToString()) : (".");
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
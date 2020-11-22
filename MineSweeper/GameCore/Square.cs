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
    public static string SquareAsString(Square square)
    {
      if (square.SquareType == SquareType.Safe)
      {
        var squareSymbol = square.SquareHintValue > 0 ? (square.SquareHintValue.ToString()) : (".");
        return squareSymbol;
      }
      if (square.IsFlagged)
      {
        return "F";
      }
      else
      {
        return "*";
      }
    }
  }
}
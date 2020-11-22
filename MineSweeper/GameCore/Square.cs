namespace MineSweeper
{
  public class Square
  {
    public SquareType SquareType;
    public int SquareHintValue;
    public Square(SquareType squareType, int hintValue)
    {
      SquareType = squareType;
      SquareHintValue = hintValue;
    }
    public static string SquareAsString(Square square)
    {
      if (square.SquareType == SquareType.Safe)
      {
        var squareSymbol = square.SquareHintValue > 0 ? (square.SquareHintValue.ToString()) : (".");
        return squareSymbol;
      }
      else
      {
        return "*";
      }
    }
  }
}
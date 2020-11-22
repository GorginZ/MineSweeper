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
    public string SquareAsString()
    {
      if (this.SquareType == SquareType.Safe)
      {
        var squareSymbol = this.SquareHintValue > 0 ? (this.SquareHintValue.ToString()) : (".");
        return squareSymbol;
      }
      else
      {
        return "*";
      }
    }
  }
}
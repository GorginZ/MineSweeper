namespace MineSweeper
{
  public class Square
  {
    public SquareType SquareType;
    public int SquareHintValue;
    public bool Revealed;
    public Square(SquareType squareType, int hintValue, bool revealed)
    {
      SquareType = squareType;
      SquareHintValue = hintValue;
      Revealed = revealed;
    }


  }
}
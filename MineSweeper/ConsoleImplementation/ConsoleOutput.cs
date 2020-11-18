using System;
using System.Text;

namespace MineSweeper.ConsoleImplementation
{
  public class ConsoleOutput : IOutPut
  {
    public void DisplayField(MineField field)
    {
      Console.WriteLine(FieldAsString(field));
    }

    public string FieldAsString(MineField mineField)
    {
      var printableField = new StringBuilder();

      for (int i = 0; i < mineField.RowDimension; i++)
      {
        for (int j = 0; j < mineField.ColumnDimension; j++)
        {
          var squareSymbol = mineField.Field[i, j].Revealed ? (SquareAsString(mineField.Field[i, j])) : (" ");

          printableField.Append(squareSymbol);

        }
        printableField.Append("\n");
      }
      return printableField.ToString();
    }
    public string SquareAsString(Square square)
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
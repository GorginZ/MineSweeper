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

      for (int i = 0; i < mineField.RowDimension - 1; i++)
      {
        for (int j = 0; j < mineField.ColumnDimension; j++)
        {
          var coordinate = new RowColumn(i, j);

          printableField.Append(SquareAsString(mineField.Field[coordinate.Row, coordinate.Column]));
        }
        printableField.Append("\n");
      }
      return printableField.ToString();
    }
    public string SquareAsString(Square square)
    {
      if (square.SquareType == SquareType.Safe)
      {
        return square.SquareHintValue.ToString();
      }
      else
      {
        return "*";

      }
    }

  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
  public class Game
  {
    private MineField _field;

    public Game(MineField field)
    {
      _field = field;
    }

    public Square[,] GetField()
    {
      return _field.Field;
    }

    public static string FieldAsString(MineField mineField)
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
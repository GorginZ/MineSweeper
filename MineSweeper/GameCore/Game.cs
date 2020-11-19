using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
  public class Game
  {
    private MineField _field;
    private HashSet<RowColumn> _revealed;

    public Game(MineField field)
    {
      _field = field;
      _revealed = new HashSet<RowColumn>();
    }

    public Square[,] GetField()
    {
      return _field.Field;
    }

    public string FieldAsString()
    {
      var printableField = new StringBuilder();

      for (int i = 0; i < _field.RowDimension; i++)
      {
        for (int j = 0; j < _field.ColumnDimension; j++)
        {
          var squareSymbol = _revealed.Contains(new RowColumn(i,j)) ? (SquareAsString(_field.Field[i, j])) : (" ");
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
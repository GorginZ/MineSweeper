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
          var squareSymbol = _revealed.Contains(new RowColumn(i, j)) ? (SquareAsString(_field.Field[i, j])) : (" ");
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
    public HashSet<RowColumn> FindEmptySquaresAdjacentToThisEmptySquare(RowColumn emptySquare, out bool FoundSquares)
    {
      FoundSquares = false;
      HashSet<RowColumn> emptySquares = new HashSet<RowColumn> { emptySquare };
      HashSet<RowColumn> adjacentSquares = _field.GetNeighboursOfSquare(emptySquare.Row, emptySquare.Column);
      foreach (RowColumn index in adjacentSquares)
      {
        if (_field.Field[index.Row, index.Column].SquareHintValue == 0)
        {
          emptySquares.Add(index);
          FoundSquares = true;
        }
      }

      return emptySquares;
    }
    public HashSet<RowColumn> EmptySquareProcess(RowColumn emptySquare)
    {
      bool stillFindingSquares = false;
      var emptySquares = FindEmptySquaresAdjacentToThisEmptySquare(emptySquare, out bool FoundSquares);
      do
      {
        foreach (RowColumn square in emptySquares)
        {
          emptySquares.UnionWith(FindEmptySquaresAdjacentToThisEmptySquare(square, out bool foundSquares));
          stillFindingSquares = foundSquares;
        }

      } while (stillFindingSquares);
      return emptySquares;
    }

    public void UpdateVisability(HashSet<RowColumn> emptySquares)
    {
      _revealed.UnionWith(emptySquares);
      foreach (RowColumn emptySquare in emptySquares)
      {
        _revealed.UnionWith(_field.GetNeighboursOfSquare(emptySquare.Row, emptySquare.Column));
      }
    }
    public void ProcessSquare(RowColumn selectedSquare)
    {
      if (_field.Field[selectedSquare.Row, selectedSquare.Column].SquareHintValue == 0)
      {
        EmptySquareProcess(selectedSquare);
      }
    }
    public bool IsMine(RowColumn index)
    {
      return SquareType.Mine == _field.Field[index.Row, index.Column].SquareType;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
  public class Game {
    private readonly MineField _field;
    private readonly HashSet<RowColumn> _revealed;
    private readonly HashSet<RowColumn> _flagged;

    public Game(MineField field)
    {
      _field = field;
      _revealed = new HashSet<RowColumn>();
      _flagged = new HashSet<RowColumn>();
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
          if (_revealed.Contains(new RowColumn(i, j)))
          {
            printableField.Append(_field.Field[i,j].SquareAsString());
            continue;
          }
          else
          {
            var value = !_flagged.Contains(new RowColumn(i, j)) ? " " : "F";
            printableField.Append(value);
          }
        }
        printableField.Append("\n");
      }
      return printableField.ToString();
    }

    public void HandleSelectedSquare(RowColumn selectedSquare)
    {
      if (IsMine(selectedSquare))
      {
        FindAndRevealMines();
      }
      if (_revealed.Contains(selectedSquare))
      {
        return;
      }
      if (!IsMine(selectedSquare) || _field.Field[selectedSquare.Row, selectedSquare.Column].SquareHintValue != 0)
      {
        _revealed.Add(selectedSquare);
      }
      if (_field.Field[selectedSquare.Row, selectedSquare.Column].SquareHintValue == 0)
      {
        RevealAllAssociatedAdjacentSquaresProcess(selectedSquare);
      }
    }
    public void RevealAllAssociatedAdjacentSquaresProcess(RowColumn selectedSquare)
    {
      var neighbours = _field.GetNeighboursOfSquare(selectedSquare.Row, selectedSquare.Column);
      foreach (RowColumn index in neighbours)
      {
        HandleSelectedSquare(index);
      }
    }
    public bool IsMine(RowColumn index)
    {
      return SquareType.Mine == _field.Field[index.Row, index.Column].SquareType;
    }
    private void FindAndRevealMines()
    {
      for (int row = 0; row < _field.RowDimension; row++)
      {
        for (int column = 0; column < _field.ColumnDimension; column++)
        {
          if (IsMine(new RowColumn(row, column)))
          {
            _revealed.Add(new RowColumn(row, column));
          }
        }
      }
    }
    public void ProcessFirstHit(RowColumn selectedSquare)
    {
      if (!IsMine(selectedSquare))
      {
        HandleSelectedSquare(selectedSquare);
      }
      if (IsMine(selectedSquare))
      {
        _field.MineHitOnFirstHitReArrange(selectedSquare);
        HandleSelectedSquare(selectedSquare);
      }
    }
    public void FlagSquare(RowColumn selectedSquare)
    {
      _flagged.Add(selectedSquare);
    }
  }
}
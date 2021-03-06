using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private readonly MineField _field;
    public bool HasPlayerLost;

    public Game(MineField field)
    {
      _field = field;
    }

    public string GetCurrentField()
    {
      return this._field.FieldAsString();
    }
    public void HandleFirstHit(RowColumn index)
    {
      if (_field[index].SquareType == SquareType.Mine)
      {
        _field.MineHitOnFirstHitReArrange(index);
      }
      HitSelectedSquare(index);
    }
    public void HitSelectedSquare(RowColumn index)
    {
      try
      {
        if (_field[index].SquareType == SquareType.Mine)
        {
          FindAndRevealMines();
          this.HasPlayerLost = true;
        }
        if (_field[index].IsRevealed)
        {
          return;
        }
        if (_field[index].SquareType != SquareType.Mine || _field[index].SquareType != 0)
        {
          _field[index].IsRevealed = true;
        }
        if (_field[index].SquareType == 0)
        {
          RevealAllAssociatedAdjacentSquaresProcess(index);
        }
      }
    }
    private void RevealAllAssociatedAdjacentSquaresProcess(RowColumn index)
    {
      var neighbours = _field.GetNeighboursOfSquare(index.Row, index.Column);
      foreach (RowColumn rowCol in neighbours)
      {
        HitSelectedSquare(rowCol);
      }
    }
    private void FindAndRevealMines()
    {
      foreach (var square in _field.Where(square => square.SquareType == SquareType.Mine))
      {
        square.IsRevealed = true;
      }
    }
    public void FlagSquare(RowColumn index)
    {
      _field[index].IsFlagged = true;
    }
    public bool HasWon()
    {
      return _field.RevealedCount == ((_field.RowDimension * _field.ColumnDimension) - (_field.MineCount));
    }
  }
}
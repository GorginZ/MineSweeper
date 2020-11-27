using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private readonly MineField _field;
    public bool PlayerLost;

    public Game(MineField field)
    {
      _field = field;
    }

    public string GetCurrentField()
    {
      return this._field.FieldAsString();
    }
    public void HandleSelectedSquare(RowColumn squareIndex)
    {
      if (_field[squareIndex].SquareType == SquareType.Mine)
      {
        FindAndRevealMines();
        this.PlayerLost = true;
      }
      if (_field[squareIndex].IsRevealed)
      {
        return;
      }
      if (_field[squareIndex].SquareType != SquareType.Mine || _field[squareIndex].SquareType != 0)
      {
        _field[squareIndex].IsRevealed = true;
      }
      if (_field[squareIndex].SquareType == 0)
      {
        RevealAllAssociatedAdjacentSquaresProcess(squareIndex);
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
    // is mine, maybedon't need this, can just be like 'is mine' kept in mienfield coz it's usd as a perdicate for other funcs
    // public bool IsMine(RowColumn index)
    // {
    //   return SquareType.Mine == _field[index].SquareType;
    // }
    private void FindAndRevealMines()
    {
      foreach (var square in _field.Where(square => square.SquareType == SquareType.Mine))
      {
        square.IsRevealed = true;
      }
    }
    public void FlagSquare(RowColumn selectedSquare)
    {
      _field[selectedSquare].IsFlagged = true;
    }
    public bool HasWon()
    {
      return _field.RevealedCount == ((_field.RowDimension * _field.ColumnDimension) - (_field.MineCount));
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private readonly MineField _field;
    public bool Haslost;

    public Game(MineField field)
    {
      _field = field;
    }

    public string GetCurrentField()
    {
      return this._field.FieldAsString();
    }
    public void HandleSelectedSquare(RowColumn selectedSquare)
    {
      if (IsMine(selectedSquare))
      {
        FindAndRevealMines();
        this.Haslost = true;
      }
      if (_field[selectedSquare].IsRevealed)
      {
        return;
      }
      if (!IsMine(selectedSquare) || _field[selectedSquare].SquareHintValue != 0)
      {
        _field[selectedSquare].IsRevealed = true;
      }
      if (_field[selectedSquare].SquareHintValue == 0)
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
      return SquareType.Mine == _field[index].SquareType;
    }
    private void FindAndRevealMines()
    {
      foreach (var square in _field.Where(square => square.SquareType == SquareType.Mine))
      {
        square.IsRevealed = true;
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
      _field[selectedSquare].IsFlagged = true;
    }
    public bool HasWon()
    {
      return _field.MineCount == _field.RevealedCount;
    }
  }
}
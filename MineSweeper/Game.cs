using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
  public class Game
  {
    private MineField _field;

    public Game(int rowDimension, int columnDimension, int numberOfMines, IMinePlacementGeneration minePlacementGeneration)
    {
      _field = new MineField(rowDimension, columnDimension, numberOfMines, minePlacementGeneration);
    }

    public Square[,] GetField()
    {
      return _field.Field;
    }



    public bool IsMine(RowColumn index)
    {
      return SquareType.Mine == _field.Field[index.Row, index.Column].SquareType;
    }

  }
}
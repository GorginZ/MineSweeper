using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
  public class Grid<TItemType>
  {
    private readonly TItemType[,] _cellGrid;

    public Grid(int rowDimension, int columnDimension)
    {
      _cellGrid = new TItemType[rowDimension, columnDimension];
    }

    public int RowCount => _cellGrid.GetLength(0);
    public int ColumnCount => _cellGrid.GetLength(1);

    public TItemType this[int row, int column]
    {
      get => _cellGrid[row, column];
      set => _cellGrid[row, column] = value;
    }

    public TItemType this[RowColumn coordinates]
    {
      get => _cellGrid[coordinates.Row, coordinates.Column];
      set => _cellGrid[coordinates.Row, coordinates.Column] = value;
    }

    public void SetAllCells(TItemType value)
    {
      // two forloop
    }

    public void SetMany(List<RowColumn> coordinatesToSet, TItemType value)
    {
      foreach (RowColumn coordinate in coordinatesToSet)
      {
        if (coordinate.Column < ColumnCount && coordinate.Row < RowCount)
        {
          this[coordinate] = value;
        }
      }
    }

  
  }
}

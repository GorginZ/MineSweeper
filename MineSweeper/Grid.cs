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

    public TItemType this[RowColumn indexRowColumn]
    {
      get => _cellGrid[indexRowColumn.Row, indexRowColumn.Column];
      set => _cellGrid[indexRowColumn.Row, indexRowColumn.Column] = value;
    }

    public void SetAllCells(TItemType value)
    {

      for (int i = 0; i < RowCount; i++)
      {
        for (int j = 0; j < ColumnCount; j++)
        {
          this[i,j] = value;
        }
    }
    }

    public void SetMany(IEnumerable<RowColumn> indexesToSet, TItemType value)
    {
      foreach (RowColumn coordinate in indexesToSet)
      {
        if (coordinate.Column < ColumnCount && coordinate.Row < RowCount)
        {
          this[coordinate] = value;
        }
      }
    }

  
  }
}

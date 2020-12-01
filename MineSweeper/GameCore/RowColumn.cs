namespace MineSweeper
{
  public readonly struct RowColumn
  {
    public readonly int Row;
    public readonly int Column;

    public RowColumn(int row, int column)
    {
      Row = row;
      Column = column;
    }
    public override bool Equals(object obj)
    {
      if (!(obj is RowColumn))
        return false;
      RowColumn other = (RowColumn)obj;
      return other.Row == Row && other.Column == Column;
    }
    public override int GetHashCode() => (Row, Column).GetHashCode();
  }
}


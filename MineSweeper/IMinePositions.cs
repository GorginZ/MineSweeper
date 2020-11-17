using System.Collections.Generic;

namespace MineSweeper
{
    public interface IMinePositions
    {
        HashSet<RowColumn> GetMinePositions(int rowDimension, int columnDimension, int numberOfMines); 
    }
}
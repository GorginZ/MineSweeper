using System.Collections.Generic;

namespace MineSweeper
{
    public interface IMinePlacementGeneration
    {
        HashSet<RowColumn> GetMinePositions(int rowDimension, int columnDimension, int numberOfMines); 
    }
}
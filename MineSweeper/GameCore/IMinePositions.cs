using System.Collections.Generic;

namespace MineSweeper
{
    public interface IMinePositions
    {
        IEnumerable<RowColumn> GetMinePositions();
    }
}
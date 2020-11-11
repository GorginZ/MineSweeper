using System;
using Xunit;

namespace MineSweeper.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateFieldOfMinesAndSafeCells()
        {
            var game = new Game(3,3);
           var field =  game.GetField();
//           Assert.Equal(field[0,0], CellContents.Safe);
           Assert.Equal(field[0,1], CellContents.Mine);

        }
    }
}

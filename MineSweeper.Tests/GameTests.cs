using System;
using Xunit;

namespace MineSweeper.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateFieldOfMinesAndSafeCells()
        {
            var game = new Game(3,3,1);
           var field =  game.GetField();
          Assert.Equal(field[0,0], CellContents.Safe);

        }
        [Fact]
        public void CanInitializeFieldWithNumberOfMines()
        {
          var game = new Game (20,30,10);
          var mineField = game.GetField();
        }
    }
}

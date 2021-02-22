using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
namespace GameOfLifeUnitTest
{
    [TestClass]
    public class GameOfLifeUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int Rows = 2;
            int Columns = 2;
            int Generations = 1;

            GameOfLifeO.GameOfLife gameoflife = new GameOfLifeO.GameOfLife();

           StringBuilder str = gameoflife.GameOfLifestr(Rows, Columns, Generations);

            Assert.IsNotNull(str);

        }
    }
}

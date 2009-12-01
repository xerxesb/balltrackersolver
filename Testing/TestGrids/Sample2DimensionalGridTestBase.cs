using NUnit.Framework;
using Solver.Models;

namespace Testing.TestGrids
{
    public abstract class Sample2DimensionalGridTestBase
    {
        [Test]
        public void Test_EmptySquareGridWithBallInCentre()
        {
            var grid = TestGridGenerator.EmptySquareGridWithBallInCentre();
            PerformAssertionsFor_EmptySquareGridWithBallInCentre(grid);
        }

        [Test]
        public void Test_SquareGridWithBallInCentreSurroundedByBricks()
        {
            var grid = TestGridGenerator.SquareGridWithBallInCentreSurroundedByBricks();
            PerformAssertionsFor_SquareGridWithBallInCentreSurroundedByBricks(grid);
        }

        protected abstract void PerformAssertionsFor_SquareGridWithBallInCentreSurroundedByBricks(Grid grid);
        protected abstract void PerformAssertionsFor_EmptySquareGridWithBallInCentre(Grid grid);
    }
}
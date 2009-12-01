using NUnit.Framework;
using Solver.Models;

namespace Testing.TestGrids
{
    public abstract class Sample1DimensionalGridTestBase
    {
        [Test]
        public void Test_SingleRowWithExitOnRight()
        {
            var grid = TestGridGenerator.SingleRowWithExitOnRight();
            PerformAssertionsFor_SingleRowWithExitOnRight(grid);
        }

        [Test]
        public void Test_SingleRowWithExitOnLeft()
        {
            var grid = TestGridGenerator.SingleRowWithExitOnLeft();
            PerformAssertionsFor_SingleRowWithExitOnLeft(grid);
        }

        [Test]
        public void Test_SingleColumnWithExitOnTop()
        {
            var grid = TestGridGenerator.SingleColumnWithExitOnTop();
            PerformAssertionsFor_SingleColumnWithExitOnTop(grid);
        }

        [Test]
        public void Test_SingleColumnWithExitOnBottom()
        {
            var grid = TestGridGenerator.SingleColumnWithExitOnBottom();
            PerformAssertionsFor_SingleColumnWithExitOnBottom(grid);
        }

        protected abstract void PerformAssertionsFor_SingleColumnWithExitOnBottom(Grid grid);
        protected abstract void PerformAssertionsFor_SingleColumnWithExitOnTop(Grid grid);
        protected abstract void PerformAssertionsFor_SingleRowWithExitOnLeft(Grid grid);
        protected abstract void PerformAssertionsFor_SingleRowWithExitOnRight(Grid grid);
    }
}
using System;
using System.Drawing;
using NUnit.Framework;
using Solver.Models;
using Testing.TestGrids;

namespace Testing.Models
{
    public class GridTests
    {
        [TestFixture]
        public class TestBlockExistsInDirection : Sample1DimensionalGridTestBase
        {
            protected override void PerformAssertionsFor_SingleColumnWithExitOnBottom(Grid grid)
            {
                var blockExistsInDirection = grid.NonAdjacentBlockExistsInDirection(Direction.Down);
                Assert.That(blockExistsInDirection, Is.True);
            }

            protected override void PerformAssertionsFor_SingleColumnWithExitOnTop(Grid grid)
            {
                var blockExistsInDirection = grid.NonAdjacentBlockExistsInDirection(Direction.Up);
                Assert.That(blockExistsInDirection, Is.True);
            }

            protected override void PerformAssertionsFor_SingleRowWithExitOnLeft(Grid grid)
            {
                var blockExistsInDirection = grid.NonAdjacentBlockExistsInDirection(Direction.Left);
                Assert.That(blockExistsInDirection, Is.True);
            }

            protected override void PerformAssertionsFor_SingleRowWithExitOnRight(Grid grid)
            {
                var blockExistsInDirection = grid.NonAdjacentBlockExistsInDirection(Direction.Right);
                Assert.That(blockExistsInDirection, Is.True);
            }
        }

        [TestFixture]
        public class TestMoveBallInDirection : Sample2DimensionalGridTestBase
        {
            protected override void PerformAssertionsFor_SquareGridWithBallInCentreSurroundedByBricks(Grid grid)
            {
                grid.MoveBallInDirection(Direction.Up);
                Assert.That(grid.Ball, Is.EqualTo(new Point(3, 2)));
                grid.SetBall(3, 3);

                grid.MoveBallInDirection(Direction.Down);
                Assert.That(grid.Ball, Is.EqualTo(new Point(3, 4)));
                grid.SetBall(3, 3);

                grid.MoveBallInDirection(Direction.Left);
                Assert.That(grid.Ball, Is.EqualTo(new Point(2, 3)));
                grid.SetBall(3, 3);

                grid.MoveBallInDirection(Direction.Right);
                Assert.That(grid.Ball, Is.EqualTo(new Point(4, 3)));
                grid.SetBall(3, 3);
            }

            protected override void PerformAssertionsFor_EmptySquareGridWithBallInCentre(Grid grid)
            {
                Assert.Throws<Exception>(() => grid.MoveBallInDirection(Direction.Up));
                Assert.Throws<Exception>(() => grid.MoveBallInDirection(Direction.Down));
                Assert.Throws<Exception>(() => grid.MoveBallInDirection(Direction.Left));
                Assert.Throws<Exception>(() => grid.MoveBallInDirection(Direction.Right));
            }
        }
    }
}
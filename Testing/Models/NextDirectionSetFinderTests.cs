using System;
using System.Collections.Generic;
using NUnit.Framework;
using Solver;
using Solver.Models;
using Testing.TestGrids;

namespace Testing.Models
{
    public class NextDirectionSetFinderTests
    {
        [TestFixture]
        public class TestFindNextDirectionSetForBall : Sample2DimensionalGridTestBase
        {
            private NextDirectionSetFinder _nextDirectionFinder;

            [SetUp]
            public void SetUp()
            {
                _nextDirectionFinder = new NextDirectionSetFinder();
            }

            protected override void PerformAssertionsFor_EmptySquareGridWithBallInCentre(Grid grid)
            {
                var directions = _nextDirectionFinder.Find(grid);
                Assert.That(directions, Is.EquivalentTo(new List<Direction>()));
            }

            protected override void PerformAssertionsFor_SquareGridWithBallInCentreSurroundedByBricks(Grid grid)
            {
                var directions = _nextDirectionFinder.Find(grid);
                Assert.That(directions, Is.EquivalentTo(new List<Direction> { Direction.Up, Direction.Right, Direction.Left, Direction.Down }));
            }
        }
    }
}
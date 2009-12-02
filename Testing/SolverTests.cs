using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Solver;
using Testing.TestGrids;

namespace Testing
{
    public class SolverTests
    {
        [TestFixture]
        public class BasicVerticalSolver
        {
            [Test]
            public void CanSolve()
            {
                var solver = new Solver.Solver(TestGridGenerator.SingleColumnWithExitOnBottom());
                solver.SolveProblem();
            }
        }

        [TestFixture]
        public class BasicHoriztontalSolver
        {
            [Test]
            public void CanSolve()
            {
                var solver = new Solver.Solver(TestGridGenerator.SingleRowWithExitOnLeft());
                solver.SolveProblem();
            }
        }

        [TestFixture]
        public class FourStageSolutionSolver
        {
            [Test]
            public void CanSolve()
            {
                var solver = new Solver.Solver(TestGridGenerator.SquareGridWithFourStageSolution());
                solver.SolveProblem();
            }
        }

        [TestFixture]
        public class InfinateLoopSolver
        {
            [Test]
            public void CanSolve()
            {
                var solver = new Solver.Solver(TestGridGenerator.GridWithInfinateLoop());
                solver.SolveProblem();
            }
        }

        [TestFixture]
        public class TheRealTest
        {
            [Test]
            public void CanSolve()
            {
                var solver = new Solver.Solver(TestGridGenerator.TheRealTest());
//                solver.SolveProblem();
            }
        }
    }
}

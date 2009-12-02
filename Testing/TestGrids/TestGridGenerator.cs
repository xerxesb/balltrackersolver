using System;
using Solver.Models;

namespace Testing.TestGrids
{
    public class TestGridGenerator
    {
        public static Grid SingleRowWithExitOnRight()
        {
            var grid = new Grid(4, 1);
            grid.AddBrick(4, 1, true, Direction.Right);
            grid.SetBall(1, 1);
            return grid;
        }

        public static Grid SingleRowWithExitOnLeft()
        {
            var grid = new Grid(4, 1);
            grid.AddBrick(1, 1, true, Direction.Left);
            grid.SetBall(4, 1);
            return grid;
        }

        public static Grid SingleColumnWithExitOnTop()
        {
            var grid = new Grid(1, 4);
            grid.AddBrick(1, 1, true, Direction.Up);
            grid.SetBall(1, 4);
            return grid;
        }

        public static Grid SingleColumnWithExitOnBottom()
        {
            var grid = new Grid(1, 4);
            grid.AddBrick(1, 4, true, Direction.Down);
            grid.SetBall(1, 1);
            return grid;
        }

        public static Grid EmptySquareGridWithBallInCentre()
        {
            var grid = new Grid(5, 5);
            grid.SetBall(3, 3);
            return grid;
        }

        public static Grid SquareGridWithBallInCentreSurroundedByBricks()
        {
            var grid = new Grid(5, 5);
            grid.AddBrick(3, 1, false, Direction.Up);
            grid.AddBrick(1, 3, false, Direction.Up);
            grid.AddBrick(5, 3, false, Direction.Up);
            grid.AddBrick(3, 5, false, Direction.Up);
            grid.SetBall(3, 3);
            return grid;
        }

        public static Grid SquareGridWithFourStageSolution()
        {
            var grid = new Grid(5, 5);
            grid.AddBrick(1, 5, false, Direction.Up);
            grid.AddBrick(5, 4, false, Direction.Up);
            grid.AddBrick(4, 1, false, Direction.Up);
            grid.AddBrick(2, 2, true, Direction.Left);

            grid.SetBall(1, 1);
            return grid;
        }

        public static Grid GridWithInfinateLoop()
        {
            var grid = new Grid(5, 5);
            grid.AddBrick(1, 2);
            grid.AddBrick(2, 5);
            grid.AddBrick(4, 1);
            grid.AddBrick(5, 4);

            grid.SetBall(2, 2);
            return grid;
        }

        public static Grid TheRealTest()
        {
            var grid = new Grid(18, 22);
            grid.AddBrick(17, 10, true, Direction.Right);
            grid.AddBrick(2, 1);
            grid.AddBrick(3, 1);
            grid.AddBrick(10, 1);
            grid.AddBrick(14, 1);
            grid.AddBrick(15, 1);
            grid.AddBrick(8, 2);
            grid.AddBrick(10, 2);
            grid.AddBrick(5, 3);
            grid.AddBrick(10, 3);
            grid.AddBrick(16, 3);
            grid.AddBrick(1, 4);
            grid.AddBrick(10, 4);
            grid.AddBrick(18, 4);
            grid.AddBrick(10, 5);
            grid.AddBrick(15, 5);
            grid.AddBrick(4, 6);
            grid.AddBrick(10, 6);
            grid.AddBrick(9, 7);
            grid.AddBrick(10, 7);
            grid.AddBrick(13, 7);
            grid.AddBrick(5, 8);
            grid.AddBrick(10, 8);
            grid.AddBrick(11, 8);
            grid.AddBrick(12, 8);
            grid.AddBrick(8, 9);
            grid.AddBrick(9, 9);
            grid.AddBrick(10, 9);
            grid.AddBrick(12, 9);
            grid.AddBrick(4, 10);
            grid.AddBrick(10, 10);
            grid.AddBrick(1, 11);
            grid.AddBrick(10, 11);
            grid.AddBrick(13, 11);
            grid.AddBrick(14, 11);
            grid.AddBrick(8, 12);
            grid.AddBrick(10, 12);
            grid.AddBrick(3, 13);
            grid.AddBrick(5, 13);
            grid.AddBrick(8, 13);
            grid.AddBrick(10, 13);
            grid.AddBrick(14, 13);
            grid.AddBrick(15, 13);
            grid.AddBrick(1, 14);
            grid.AddBrick(3, 14);
            grid.AddBrick(7, 14);
            grid.AddBrick(8, 14);
            grid.AddBrick(10, 14);
            grid.AddBrick(11, 14);
            grid.AddBrick(14, 14);
            grid.AddBrick(8, 15);
            grid.AddBrick(10, 15);
            grid.AddBrick(15, 15);
            grid.AddBrick(10, 16);
            grid.AddBrick(4, 17);
            grid.AddBrick(10, 17);
            grid.AddBrick(8, 18);
            grid.AddBrick(10, 18);
            grid.AddBrick(12, 18);
            grid.AddBrick(18, 18);
            grid.AddBrick(6, 19);
            grid.AddBrick(10, 19);
            grid.AddBrick(14, 19);
            grid.AddBrick(2, 20);
            grid.AddBrick(10, 20);
            grid.AddBrick(8, 21);
            grid.AddBrick(12, 21);
            grid.AddBrick(17, 21);
            grid.AddBrick(9, 22);
            grid.AddBrick(13, 22);
            grid.SetBall(3, 7);
            return grid;
        }
    }
}
/*
1, 1	2, 1	3, 1	4, 1	5, 1
1, 2	2, 2	3, 2	4, 2	5, 2
1, 3	2, 3	3, 3	4, 3	5, 3
1, 4	2, 4	3, 4	4, 4	5, 4
1, 5	2, 5	3, 5	4, 5	5, 5
*/

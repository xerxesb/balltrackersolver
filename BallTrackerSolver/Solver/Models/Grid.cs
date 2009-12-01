using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Solver.Models
{
    // Grid works on a 1,1 coordinate system. (ie: there is no counting from zero when consuming this class
    // ie: Width(4) means 4 bricks long, and Left(4) means the 4th brick
    public class Grid
    {
        private readonly int _width;
        private readonly int _height;
        private Brick[,] _blockGrid;
        private Point _ball;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _blockGrid = new Brick[width, height];
        }

        public Point Ball
        {
            get { return new Point(_ball.X + 1, _ball.Y + 1); }
        }

        public void SetBall(int left, int top)
        {
            _ball.X = left - 1;
            _ball.Y = top - 1;
        }

        public void AddBrick(int left, int top, bool isExitBrick, Direction directionOfEntryIfExit)
        {
            _blockGrid[left - 1, top - 1] = new Brick(isExitBrick, directionOfEntryIfExit);
        }

        public bool NonAdjacentBlockExistsInDirection(Direction direction)
        {
            var nextBlockInDirection = FindNextBlockInDirection(direction);
            return nextBlockInDirection != null && !IsAdjacentToBall(nextBlockInDirection.Value);
        }

        public bool AlreadyMovedInThisDirection(Direction direction)
        {
            var nextBlockInDirection = FindNextBlockInDirection(direction);
            return nextBlockInDirection != null && alreadyVisitedLocations.Contains(nextBlockInDirection.Value);
        }

        private bool IsAdjacentToBall(Point nextBlockInDirection)
        {
            return nextBlockInDirection.X == _ball.X - 1
                   || nextBlockInDirection.X == _ball.X + 1
                   || nextBlockInDirection.Y == _ball.Y - 1
                   || nextBlockInDirection.Y == _ball.Y + 1;

        }

        public void MoveBallInDirection(Direction direction)
        {
            var pointOfNextBlock = FindNextBlockInDirection(direction);

            if (pointOfNextBlock == null)
            {
                throw new Exception(String.Format("We fell off the board - wtf? [Direction: {0}]", direction));
            }

            if (direction == Direction.Up)
            {
                _ball.Y = pointOfNextBlock.Value.Y + 1;
            }

            if (direction == Direction.Down)
            {
                _ball.Y = pointOfNextBlock.Value.Y - 1;
            }

            if (direction == Direction.Left)
            {
                _ball.X = pointOfNextBlock.Value.X + 1;
            }

            if (direction == Direction.Right)
            {
                _ball.X = pointOfNextBlock.Value.X - 1;
            }

            alreadyVisitedLocations.Add(_ball);
        }

        List<Point> alreadyVisitedLocations = new List<Point>();

        private Point? FindNextBlockInDirection(Direction direction)
        {
            Point? result = null;

            if (direction == Direction.Up)
            {
                for (var i = _ball.Y; i >= 0; i--)
                {
                    if (_blockGrid[_ball.X, i] != null)
                    {
                        result = new Point(_ball.X, i);
                        break;
                    }
                }
            }

            if (direction == Direction.Down)
            {
                for (var i = _ball.Y; i < _height; i++)
                {
                    if (_blockGrid[_ball.X, i] != null)
                    {
                        result = new Point(_ball.X, i);
                        break;
                    }
                }
            }

            if (direction == Direction.Left)
            {
                for (var i = _ball.X; i >= 0; i--)
                {
                    if (_blockGrid[i, _ball.Y] != null)
                    {
                        result = new Point(i, _ball.Y);
                        break;
                    }
                }
            }

            if (direction == Direction.Right)
            {
                for (var i = _ball.X; i < _width; i++)
                {
                    if (_blockGrid[i, _ball.Y] != null)
                    {
                        result = new Point(i, _ball.Y);
                        break;
                    }
                }
            }

            return result;
        }

        public bool HasExitBrickNextToBallInDirection(Direction direction)
        {
            Brick adjacentBlock = null;

            if (direction == Direction.Left)
            {
                adjacentBlock = _blockGrid[_ball.X - 1, _ball.Y];
            }

            if (direction == Direction.Right)
            {
                adjacentBlock = _blockGrid[_ball.X + 1, _ball.Y];
            }

            if (direction == Direction.Up)
            {
                adjacentBlock = _blockGrid[_ball.X, _ball.Y - 1];
            }

            if (direction == Direction.Down)
            {
                adjacentBlock = _blockGrid[_ball.X, _ball.Y + 1];
            }

            return adjacentBlock != null
                   && adjacentBlock.IsLevelExit
                   && adjacentBlock.DirectionOfEntryForExit == direction;
        }

        public void AddBrick(int left, int top)
        {
            AddBrick(left, top, false, Direction.Up);
        }
    }
}
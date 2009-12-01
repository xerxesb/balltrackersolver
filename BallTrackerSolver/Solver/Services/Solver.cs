using System;
using System.Collections.Generic;
using Solver.Models;

namespace Solver
{
    public class Solver
    {
        private readonly Grid _grid;
        private NextDirectionSetFinder _nextDirectionSetFinder;
        private List<Direction> _solutionQueue;

        public Solver(Grid grid)
        {
            _grid = grid;
            _nextDirectionSetFinder = new NextDirectionSetFinder();
            _solutionQueue = new List<Direction>();
        }

        public void SolveProblem()
        {
            var nextAvailableDirections = _nextDirectionSetFinder.Find(_grid);
            var result = FindExitForBall(nextAvailableDirections);
            Console.WriteLine("Exit Strategy discovered:");

            _solutionQueue.Reverse();
            foreach (var direction in _solutionQueue)
            {
                Console.WriteLine(direction);
            }

        }

        private bool FindExitForBall(IList<Direction> nextAvailableDirections)
        {
            var originalBallPosition = _grid.Ball;
            var foundExitPath = false;

            foreach (var direction in nextAvailableDirections)
            {
                _grid.SetBall(originalBallPosition.X, originalBallPosition.Y);

                if (_grid.NonAdjacentBlockExistsInDirection(direction))
                {
                    _grid.MoveBallInDirection(direction);
                    foundExitPath = _grid.HasExitBrickNextToBallInDirection(direction);

                    if (foundExitPath)
                    {
                        _solutionQueue.Add(direction);
                        return true;
                    }

                    var newDirections = _nextDirectionSetFinder.Find(_grid);
                    foundExitPath = FindExitForBall(newDirections);

                    if (foundExitPath)
                    {
                        _solutionQueue.Add(direction);
                        return true;
                    }
                }
            }

            return foundExitPath;
        }
    }
}
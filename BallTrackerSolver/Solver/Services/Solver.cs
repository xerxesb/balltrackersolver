using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Solver.Models;

namespace Solver
{
    public class Solver
    {
        private readonly Grid _grid;
        private NextDirectionSetFinder _nextDirectionSetFinder;
        private Stack<Vector> _movementsTaken;

        public Solver(Grid grid)
        {
            _grid = grid;
            _nextDirectionSetFinder = new NextDirectionSetFinder();
            _movementsTaken = new Stack<Vector>();
        }

        public void SolveProblem()
        {
            var nextAvailableDirections = _nextDirectionSetFinder.Find(_grid);
            var result = FindExitForBall(nextAvailableDirections);
            Console.WriteLine("Exit Strategy discovered:");
            if (_movementsTaken.Count == 0)
                Console.WriteLine("No exit strategy found.");

            var reverseVectors = _movementsTaken.Reverse();
            foreach (var vector in reverseVectors)
            {
                Console.WriteLine(vector);
            }
        }

        private bool FindExitForBall(IList<Direction> nextAvailableDirections)
        {
            var originalBallPosition = _grid.Ball;
            var foundExitPath = false;

            foreach (var direction in nextAvailableDirections)
            {
//                Console.WriteLine("------------");
//                Console.WriteLine("Location [{0}] ; heading: [{1}]", _grid.Ball, direction);
                _grid.SetBall(originalBallPosition.X, originalBallPosition.Y);

                var alreadyTravelledThisVector = false;

                if (_grid.NonAdjacentBlockExistsInDirection(direction))
                {
                    _grid.MoveBallInDirection(direction);
                    alreadyTravelledThisVector = _movementsTaken.Contains(new Vector(_grid.Ball, direction));
                }

                _grid.SetBall(originalBallPosition.X, originalBallPosition.Y);

//                DumpVectorStack();

                if (!alreadyTravelledThisVector && _grid.NonAdjacentBlockExistsInDirection(direction))
                {
                    _grid.MoveBallInDirection(direction);

//                    Console.WriteLine("New location [{0}] ; Moved ball [{1}]", _grid.Ball, direction);

                    _movementsTaken.Push(new Vector(_grid.Ball, direction));
                    foundExitPath = _grid.HasExitBrickNextToBallInDirection(direction);

                    if (foundExitPath)
                    {
                        return true;
                    }

                    var newDirections = _nextDirectionSetFinder.Find(_grid);
                    foundExitPath = FindExitForBall(newDirections);

                    if (foundExitPath)
                    {
                        return true;
                    }

                    _movementsTaken.Pop();
                }
            }

            return foundExitPath;
        }

        private void DumpVectorStack()
        {
            Console.WriteLine("Current movement stack:");
            foreach (var vector in _movementsTaken)
            {
                Console.WriteLine("\t Point: [{0}] ; Direction: [{1}]", vector.DestinationPoint, vector.DirectionArrived);
            }
        }
    }
}
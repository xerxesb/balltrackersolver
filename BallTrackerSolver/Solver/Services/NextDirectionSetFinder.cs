using System;
using System.Collections.Generic;
using Solver.Models;

namespace Solver
{
    public class NextDirectionSetFinder
    {
        public IList<Direction> Find(Grid grid)
        {
            var result = new List<Direction>();

            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var nextBlockExists = grid.NonAdjacentBlockExistsInDirection((Direction) direction);
//                                      && !grid.AlreadyMovedInThisDirection((Direction) direction);
                if (nextBlockExists)
                {
                    result.Add((Direction) direction);
                }
            }

            return result;
        }
    }
}
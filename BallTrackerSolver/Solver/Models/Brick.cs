using System;

namespace Solver.Models
{
    public class Brick
    {
        public bool IsLevelExit { get; set; }
        public Direction DirectionOfEntryForExit { get; set; }

        public Brick(bool isLevelExit, Direction directionOfEntryForExit)
        {
            IsLevelExit = isLevelExit;
            DirectionOfEntryForExit = directionOfEntryForExit;
        }
    }
}
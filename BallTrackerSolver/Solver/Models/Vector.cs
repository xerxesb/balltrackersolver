using System;
using System.Drawing;

namespace Solver.Models
{
    public struct Vector
    {
        private readonly Point _destinationPoint;
        private readonly Direction _directionArrived;

        public Vector(Point destinationPoint, Direction directionArrived)
        {
            _destinationPoint = destinationPoint;
            _directionArrived = directionArrived;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var compareTo = (Vector) obj;
            return DestinationPoint == compareTo.DestinationPoint
                   && DirectionArrived == compareTo.DirectionArrived;
        }

        public override int GetHashCode()
        {
            return DirectionArrived.GetHashCode() & DestinationPoint.GetHashCode();
        }

        public Direction DirectionArrived
        {
            get { return _directionArrived; }
        }

        public Point DestinationPoint
        {
            get { return _destinationPoint; }
        }
    }
}
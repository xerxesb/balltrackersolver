using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using Solver.Models;

namespace Testing.Models
{
    public class VectorTests
    {
        public class TestVectorStack
        {
            private Stack<Vector> _stack;
            private Vector _vector1;
            private Vector _vector2;
            private Vector _vector3;
            private Vector _vector4;

            [SetUp]
            public void SetUp()
            {
                _stack = new Stack<Vector>();
                _vector1 = new Vector(new Point(1, 1), Direction.Left);
                _vector2 = new Vector(new Point(2, 2), Direction.Right);
                _vector3 = new Vector(new Point(3, 3), Direction.Up);
                _vector4 = new Vector(new Point(4, 4), Direction.Down);
                _stack.Push(_vector1);
                _stack.Push(_vector2);
                _stack.Push(_vector3);
                _stack.Push(_vector4);
            }

            [Test]
            public void ShouldContainVector()
            {
                var localvector = new Vector(new Point(1, 1), Direction.Left);
                Assert.That(_stack.Contains(localvector), Is.True);
            }
        }

        public class TestEquals
        {
            private Point _point;
            private Vector _vector;
            private Vector _newVector;

            [SetUp]
            public void SetUp()
            {
                _point = new Point(1, 1);
                _vector = new Vector(_point, Direction.Left);
                _newVector = new Vector(new Point(1, 1), Direction.Left);
            }

            [Test]
            public void CallingEqualsConfirmsEquality()
            {
                Assert.That(_vector.Equals(_newVector), Is.True);
            }

            [Test]
            public void UsingEqualsOperatorConfirmsEquality()
            {
                Assert.That(_vector == _newVector, Is.True);
            }

            [Test]
            public void NUnitEqualityComparerConfirmsEquality()
            {
                Assert.That(_vector, Is.EqualTo(_newVector));
            }
        }
    }
}
using NUnit.Framework;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class PositionTests : MockRobotTest
    {
        private Position position;

        [TestCase(1, 2)]
        [TestCase(45, 12)]
        public void InitialisesItsXAndYCoordinatesFromConstructorArguments(int x, int y)
        {
            GivenANewPositionWithCoordinates(x, y);

            Assert.That(position.X, Is.EqualTo(x));
            Assert.That(position.Y, Is.EqualTo(y));
        }

        [TestCase(10, 1, false)]
        [TestCase(1, 10, true)]
        public void IsPositionForChecksAgainstTheRobotsXAndYCoordinates(int robotX, int robotY, bool isPositionFor)
        {
            GivenANewPositionWithCoordinates(1, 10);
            GivenTheRobotIsAt(robotX, robotY);

            Assert.That(position.IsPositionFor(HardwareRobot), Is.EqualTo(isPositionFor));
        }

        [TestCase(23, 45, false)]
        [TestCase(2, 4, true)]
        public void ChecksEqualityByValue(int x, int y, bool isEqual)
        {
            GivenANewPositionWithCoordinates(2, 4);
            Assert.That(position.Equals(NewPosition(x, y)), Is.EqualTo(isEqual));
        }

        private void GivenANewPositionWithCoordinates(int x, int y)
        {
            position = NewPosition(x, y);
        }

        private Position NewPosition(int x, int y)
        {
            return new Position(x, y);
        }
    }
}
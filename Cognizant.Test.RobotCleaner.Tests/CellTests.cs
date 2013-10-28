using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class CellTests : MockRobotTest
    {
        private Cell cell;
        private Position position;

        [SetUp]
        public void SetUp()
        {
            position = NewMock<Position>();
            cell = new Cell(position);
        }

        [Test]
        public void IsCurrentPositionForCheckDelegatesToThePosition()
        {
            cell.IsCurrentPositionFor(HardwareRobot);

            position.AssertWasCalled(p => p.IsPositionFor(HardwareRobot));
        }

        [Test]
        public void IsAtPositionCheckDelegatesToPosition()
        {
            var queryPosition = new Position(0, 0);

            cell.IsAtPosition(queryPosition);

            position.AssertWasCalled(p => p.Equals(queryPosition));
        }

        [Test]
        public void ByDefaultCellsAreNotMarkedAsClean()
        {
            Assert.That(cell.IsClean, Is.False);
        }

        [Test]
        public void CleaningACellSetsItIsCleanFlag()
        {
            cell.Clean();

            Assert.That(cell.IsClean);
        }
    }
}
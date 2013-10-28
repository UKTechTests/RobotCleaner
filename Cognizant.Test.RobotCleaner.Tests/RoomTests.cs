using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class RoomTests : MockRobotTest
    {
        private IDirectionMapper directionMapper;
        private Room room;

        [SetUp]
        public void SetUp()
        {
            directionMapper = NewMock<IDirectionMapper>();
        }

        [TestCase(2, 2)]
        [TestCase(2, 2)]
        public void InitialisesCellsForDimensionsSpecifiedInConstructorArguments(int width, int length)
        {
            GivenARoomWithDimensions(width, length);
            IEnumerable<Cell> cells = room.Cells.ToArray();

            Assert.That(cells.Count(), Is.EqualTo(width*length));
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Assert.That(cells.Count(cell => cell.IsAtPosition(new Position(x, y))), Is.EqualTo(1));
                }
            }
        }

        [Test]
        public void IsCleanInFrontQueriesDirectionMapperForPositionFacingRobotAndChecksIsCleanFlagOnMatchingCell()
        {
            GivenARoomWithDimensions(1, 1);
            directionMapper.Stub(mapper => mapper.GetPositionFacingRobot(HardwareRobot)).Return(new Position(0, 0));
            room.Cells.First().Clean();
            Assert.That(room.IsCleanInFront(HardwareRobot));
        }

        [Test]
        public void TrackCleaningMarksTheCellAtTheRobotsCoordinatesAsClean()
        {
            GivenARoomWithDimensions(2, 2);
            room.TrackCleaning(HardwareRobot);
            Assert.That(room.Cells.First().IsClean);
            Assert.That(room.Cells.Count(cell => !cell.IsClean), Is.EqualTo(3));
        }

        [Test]
        public void HasNotFinishedCleaningIfAnyCellIsNotClean()
        {
            GivenARoomWithDimensions(1, 1);
            Assert.That(room.IsClean, Is.False);
        }

        [Test]
        public void HasFinishedCleaningWellAllCellsClean()
        {
            GivenARoomWithDimensions(2, 2);
            foreach (var cell in room.Cells)
            {
                cell.Clean();
            }
            Assert.That(room.IsClean);
        }

        private void GivenARoomWithDimensions(int width, int length)
        {
            room = new Room(width, length, directionMapper);
        }
    }
}
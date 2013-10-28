using System.Linq;
using Cognizant.Test.RobotCleaner.Navigations;
using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests.Navigations
{
    [TestFixture]
    public class CleaningTests : MockRobotTest
    {
        private Cleaning cleaning;
        private Room room;

        [SetUp]
        public void SetUp()
        {
            room = NewMock<RoomStub>();
            cleaning = new Cleaning(HardwareRobot, room);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void IsCompleteDelegatesToIsCleanFlagOnRoom(bool isRoomClean)
        {
            GivenTheCleaningIsUnderway();
            room.Stub(r => r.IsClean).Return(isRoomClean);
            Assert.That(cleaning.IsComplete, Is.EqualTo(isRoomClean));
        }

        [Test]
        public void FirstCommandIsTurnLeft()
        {
            ThenTheNextCommandIs<TurnLeftCommand>();
        }

        [Test]
        public void IfNoObstacleAndNotAlreadyCleanedFacingCellNextCommandIsWalk()
        {
            GivenTheCleaningIsUnderway();
            ThenTheNextCommandIs<WalkCommand>();
        }

        [Test]
        public void IsAnObstacleNextCommandIsTurnRight()
        {
            GivenTheCleaningIsUnderway();
            HardwareRobot.Stub(robot => robot.IsObstacle()).Return(true);
            ThenTheNextCommandIs<TurnRightCommand>();
        }

        [Test]
        public void IsAlreadyCleanedCellNextCommandIsTurnRight()
        {
            GivenTheCleaningIsUnderway();
            room.Stub(r => r.IsCleanInFront(HardwareRobot)).Return(true);
            ThenTheNextCommandIs<TurnRightCommand>();
        }

        [Test]
        public void EachCommandIsStored()
        {
            cleaning.NextCommand();
            cleaning.NextCommand();
            Assert.That(cleaning.Commands.Count(), Is.EqualTo(2));
        }

        private void ThenTheNextCommandIs<TCommand>()
        {
            Assert.That(cleaning.NextCommand(), Is.InstanceOf<TCommand>());
        }

        private void GivenTheCleaningIsUnderway()
        {
            cleaning.NextCommand();
        }
    }
}
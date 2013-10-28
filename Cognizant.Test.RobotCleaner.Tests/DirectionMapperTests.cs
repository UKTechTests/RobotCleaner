using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class DirectionMapperTests : MockRobotTest
    {
        private DirectionMapper directionMapper;

        [SetUp]
        public void SetUp()
        {
            GivenTheRobotIsAt(1, 1);
            directionMapper = new DirectionMapper();
        }

        [Test]
        public void FacingToNorthIsFacingThePositionDirectlyAbove()
        {
            GivenTheRobotIsFacing(3);
            ThenThePositionInFrontOfTheRobotIs(1, 0);
        }

        [Test]
        public void FacingToSouthIsFacingThePositionDirectlyBelow()
        {
            GivenTheRobotIsFacing(1);
            ThenThePositionInFrontOfTheRobotIs(1, 2);
        }

        [Test]
        public void FacingToEastIsFacingThePositionDirectlyRight()
        {
            GivenTheRobotIsFacing(0);
            ThenThePositionInFrontOfTheRobotIs(2, 1);
        }

        [Test]
        public void FacingToWestIsFacingThePositionDirectlyLeft()
        {
            GivenTheRobotIsFacing(2);
            ThenThePositionInFrontOfTheRobotIs(0, 1);
        }

        private void ThenThePositionInFrontOfTheRobotIs(int x, int y)
        {
            var position = directionMapper.GetPositionFacingRobot(HardwareRobot);
            Assert.That(position, Is.Not.Null);
            Assert.That(position.X, Is.EqualTo(x));
            Assert.That(position.Y, Is.EqualTo(y));
        }

        private void GivenTheRobotIsFacing(int hardwareDirection)
        {
            HardwareRobot.Stub(robot => robot.FaceTo).Return(hardwareDirection);
        }
    }
}
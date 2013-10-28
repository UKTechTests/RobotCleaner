using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class WalkCommandTests : MockRobotTest
    {
        [Test]
        public void DelegatesToTheHardwareToWalkAnTracksCleaningWithRoom()
        {
            var room = NewMock<RoomStub>();
            new WalkCommand(HardwareRobot, room).Execute();
            HardwareRobot.AssertWasCalled(robot => robot.Walk());
            room.AssertWasCalled(r => r.TrackCleaning(HardwareRobot));
        }
    }
}
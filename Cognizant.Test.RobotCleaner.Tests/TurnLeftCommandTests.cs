using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class TurnLeftCommandTests : MockRobotTest
    {
        [Test]
        public void DelegatesToTheHardwareToTurnLeft()
        {
            var room = NewMock<RoomStub>();
            new TurnLeftCommand(HardwareRobot, room).Execute();
            HardwareRobot.AssertWasCalled(robot => robot.TurnLeft());
            room.AssertWasCalled(r => r.TrackCleaning(HardwareRobot));
        }
    }
}
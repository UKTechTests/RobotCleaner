using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class TurnRightCommandTests : MockRobotTest
    {
        [Test]
        public void DelegatesToTheHardwareToTurnRight()
        {
            var room = NewMock<RoomStub>();
            new TurnRightCommand(HardwareRobot, room).Execute();
            HardwareRobot.AssertWasCalled(robot => robot.TurnRight());
            room.AssertWasCalled(r => r.TrackCleaning(HardwareRobot));
        }
    }
}
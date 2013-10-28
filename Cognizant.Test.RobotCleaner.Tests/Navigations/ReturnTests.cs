using Cognizant.Test.RobotCleaner.Navigations;
using NUnit.Framework;
using Rhino.Mocks;

namespace Cognizant.Test.RobotCleaner.Tests.Navigations
{
    [TestFixture]
    public class ReturnTests : MockRobotTest
    {
        [Test]
        public void ReturnDelegatesToResetMethodOnHardware()
        {
            new Return(HardwareRobot).Execute();
            HardwareRobot.AssertWasCalled(robot => robot.Reset());
        }
    }
}
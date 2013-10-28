using NUnit.Framework;
using Rhino.Mocks;
using RobotHardware;

namespace Cognizant.Test.RobotCleaner.Tests
{
    public abstract class MockRobotTest
    {
        protected IHardwareRobot HardwareRobot;

        [SetUp]
        public void BaseSetUp()
        {
            HardwareRobot = NewMock<IHardwareRobot>();
        }

        protected void GivenTheRobotIsAt(int x, int y)
        {
            HardwareRobot.Stub(robot => robot.X).Return(x);
            HardwareRobot.Stub(robot => robot.Y).Return(y);
        }

        protected TMock NewMock<TMock>() where TMock : class
        {
            return MockRepository.GenerateMock<TMock>();
        }
    }
}
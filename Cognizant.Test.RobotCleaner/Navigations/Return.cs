using RobotHardware;

namespace Cognizant.Test.RobotCleaner.Navigations
{
    public class Return : IReturn
    {
        private readonly IHardwareRobot hardwareRobot;

        public Return(IHardwareRobot hardwareRobot)
        {
            this.hardwareRobot = hardwareRobot;
        }

        public void Execute()
        {
            hardwareRobot.Reset();
        }
    }
}
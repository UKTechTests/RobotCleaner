using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public class TurnLeftCommand : Command
    {
        public TurnLeftCommand(IHardwareRobot hardwareRobot, Room room)
            : base(hardwareRobot, room)
        {
        }

        protected override void PerformCommandSteps()
        {
            HardwareRobot.TurnLeft();
        }
    }
}
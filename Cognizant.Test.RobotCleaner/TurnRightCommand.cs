using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public class TurnRightCommand : Command
    {
        public TurnRightCommand(IHardwareRobot hardwareRobot, Room room) : base(hardwareRobot, room)
        {
        }

        protected override void PerformCommandSteps()
        {
            HardwareRobot.TurnRight();
        }
    }
}
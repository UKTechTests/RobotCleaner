using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public class WalkCommand : Command
    {
        public WalkCommand(IHardwareRobot hardwareRobot, Room room) : base(hardwareRobot, room)
        {
        }

        protected override void PerformCommandSteps()
        {
            HardwareRobot.Walk();
        }
    }
}
using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public abstract class Command
    {
        protected Room Room;
        protected IHardwareRobot HardwareRobot;

        protected Command(IHardwareRobot hardwareRobot, Room room)
        {
            HardwareRobot = hardwareRobot;
            Room = room;
        }

        public Position PositionAfterExecuted { get; set; }
        public Position PositionBeforeExecuted { get; set; }

        public bool MovedRobot
        {
            get { return !PositionBeforeExecuted.Equals(PositionAfterExecuted); }
        }

        public virtual void Execute()
        {
            PositionBeforeExecuted = new Position(HardwareRobot.X, HardwareRobot.Y);
            PerformCommandSteps();
            PositionAfterExecuted = new Position(HardwareRobot.X, HardwareRobot.Y);
            Room.TrackCleaning(HardwareRobot);
        }

        protected abstract void PerformCommandSteps();
    }
}
using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public class Cell
    {
        public Cell(Position position)
        {
            Position = position;
        }

        public Position Position { get; private set; }
        public bool IsClean { get; private set; }

        public void Clean()
        {
            IsClean = true;
        }

        public bool IsCurrentPositionFor(IHardwareRobot hardwareRobot)
        {
            return Position.IsPositionFor(hardwareRobot);
        }

        public bool IsAtPosition(Position position)
        {
            return Position.Equals(position);
        }
    }
}
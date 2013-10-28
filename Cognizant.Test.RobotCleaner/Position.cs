using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public class Position
    {
        public static readonly Position Empty = new Position(-1, -1);

        public Position()
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public virtual bool IsPositionFor(IHardwareRobot hardwareRobot)
        {
            return X == hardwareRobot.X && Y == hardwareRobot.Y;
        }

        public virtual bool Equals(Position position)
        {
            return position != null &&
                   position.X == X &&
                   position.Y == Y;
        }
    }
}
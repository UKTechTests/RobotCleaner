using System.Collections.Generic;
using System.Linq;
using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public interface IDirectionMapper
    {
        Position GetPositionFacingRobot(IHardwareRobot hardwareRobot);
    }

    public class DirectionMapper : IDirectionMapper
    {
        private static readonly IEnumerable<Direction> Directions = new Direction[]
                                                                        {
                                                                            new North(),
                                                                            new South(),
                                                                            new East(),
                                                                            new West()
                                                                        };

        public Position GetPositionFacingRobot(IHardwareRobot hardwareRobot)
        {
            return
                Directions.Single(direction => direction.MapsToHardwareDirectionFor(hardwareRobot)).GetPositionFacing(
                    hardwareRobot);
        }
    }

    public abstract class Direction
    {
        protected Direction(int hardwareDirection)
        {
            HardwareDirection = hardwareDirection;
        }

        public int HardwareDirection { get; private set; }
        public abstract Position GetPositionFacing(IHardwareRobot hardwareRobot);

        public bool MapsToHardwareDirectionFor(IHardwareRobot hardwareRobot)
        {
            return hardwareRobot.FaceTo.Equals(HardwareDirection);
        }

        protected Position NewPosition(int x, int y)
        {
            return new Position(x, y);
        }
    }

    public class North : Direction
    {
        public North()
            : base(3)
        {
        }

        public override Position GetPositionFacing(IHardwareRobot hardwareRobot)
        {
            return NewPosition(hardwareRobot.X, hardwareRobot.Y - 1);
        }
    }

    public class South : Direction
    {
        public South()
            : base(1)
        {
        }

        public override Position GetPositionFacing(IHardwareRobot hardwareRobot)
        {
            return NewPosition(hardwareRobot.X, hardwareRobot.Y + 1);
        }
    }

    public class East : Direction
    {
        public East()
            : base(0)
        {
        }

        public override Position GetPositionFacing(IHardwareRobot hardwareRobot)
        {
            return NewPosition(hardwareRobot.X + 1, hardwareRobot.Y);
        }
    }

    public class West : Direction
    {
        public West()
            : base(2)
        {
        }

        public override Position GetPositionFacing(IHardwareRobot hardwareRobot)
        {
            return NewPosition(hardwareRobot.X - 1, hardwareRobot.Y);
        }
    }
}
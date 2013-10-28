using System.Collections.Generic;
using System.Linq;
using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public class Room
    {
        private readonly IDirectionMapper directionMapper;
        private readonly List<Cell> cells;

        public Room(int width, int length, IDirectionMapper directionMapper)
        {
            this.directionMapper = directionMapper;
            cells = new List<Cell>(width*length);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    cells.Add(new Cell(new Position(x, y)));
                }
            }
        }

        public IEnumerable<Cell> Cells
        {
            get { return cells; }
        }

        public virtual bool IsClean
        {
            get { return cells.All(cell => cell.IsClean); }
        }

        public virtual bool IsCleanInFront(IHardwareRobot hardwareRobot)
        {
            var positionInFrontOfRobot = directionMapper.GetPositionFacingRobot(hardwareRobot);
            return cells.Single(cell => cell.IsAtPosition(positionInFrontOfRobot)).IsClean;
        }

        public virtual void TrackCleaning(IHardwareRobot hardwareRobot)
        {
            cells.Single(cell => cell.IsCurrentPositionFor(hardwareRobot)).Clean();
        }
    }
}
using System.Linq;
using Cognizant.Test.RobotCleaner.Navigations;
using RobotHardware;

namespace Cognizant.Test.RobotCleaner
{
    public class Robot
    {
        private readonly IHardwareRobot hardwareRobot;
        private readonly ICleaning cleaning;
        private readonly IReturn @return;
        private readonly Room room;
        private int totalMoves;

        public Robot(IHardwareRobot hardwareRobot, int width, int length)
        {
            this.hardwareRobot = hardwareRobot;
            room = new Room(width, length, new DirectionMapper());
            cleaning = new Cleaning(hardwareRobot, room);
            @return = new Return(hardwareRobot);
        }

        public void CleanRoom()
        {
            while (!cleaning.IsComplete)
            {
                cleaning.ExecuteNextCommand();
            }
            totalMoves = hardwareRobot.TotalMovements;
            @return.Execute();
        }

        public void PrintSummary(IPrinter printer)
        {
            printer.PrintLine("[0, 0]");
            foreach (var command in cleaning.Commands.Where(c => c.MovedRobot))
            {
                printer.PrintLine(string.Format("[{0}, {1}]", command.PositionAfterExecuted.X,
                                                command.PositionAfterExecuted.Y));
            }
            printer.PrintLine(string.Format("Total Movemonts = {0}", totalMoves));
        }
    }
}
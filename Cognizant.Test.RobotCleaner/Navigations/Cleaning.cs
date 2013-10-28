using System.Collections.Generic;
using System.Linq;
using RobotHardware;

namespace Cognizant.Test.RobotCleaner.Navigations
{
    public class Cleaning : ICleaning
    {
        private readonly List<Command> commands = new List<Command>();
        private readonly IHardwareRobot hardwareRobot;
        private readonly Room room;

        public Cleaning(IHardwareRobot hardwareRobot, Room room)
        {
            this.hardwareRobot = hardwareRobot;
            this.room = room;
        }

        public bool IsComplete
        {
            get { return room.IsClean; }
        }

        public IEnumerable<Command> Commands
        {
            get { return commands; }
        }

        public void ExecuteNextCommand()
        {
            NextCommand().Execute();
        }

        public Command NextCommand()
        {
            Command command;

            if (!commands.Any())
            {
                command = new TurnLeftCommand(hardwareRobot, room);
            }
            else if (CanWalk)
            {
                command = new WalkCommand(hardwareRobot, room);
            }
            else
            {
                command = new TurnRightCommand(hardwareRobot, room);
            }

            commands.Add(command);
            return command;
        }

        private bool CanWalk
        {
            get
            {
                return !hardwareRobot.IsObstacle() &&
                       !room.IsCleanInFront(hardwareRobot);
            }
        }
    }
}
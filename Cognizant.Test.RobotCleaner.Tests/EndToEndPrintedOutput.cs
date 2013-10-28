using System.Diagnostics;
using NUnit.Framework;
using RobotHardware;

namespace Cognizant.Test.RobotCleaner.Tests
{
    [TestFixture]
    public class EndToEndPrintedOutput
    {
        [TestCase(20, 15)]
        [TestCase(4, 5)]
        [TestCase(13, 9)]
        public void TestRuns(int width, int length)
        {
            var hardware = new HardwareWithObstacles(width, length);
            var robot = new Robot(hardware, width, length);

            robot.CleanRoom();

            robot.PrintSummary(new DebugPrinter());
        }

        private class DebugPrinter : IPrinter
        {
            public void PrintLine(string line)
            {
                Debug.WriteLine(line);
            }
        }
    }
}
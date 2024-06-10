using System.Diagnostics;

namespace UtilityMonitorForWindows
{
    public static class ProcessesHelper
    {
        public static List<Process> GetAllProcessesThatCanBeKilled(string processName, int lifetime)
        {
            var result = new List<Process>();

            var startTime = DateTime.Now;

            var processes = Process.GetProcessesByName(processName);

            foreach (var process in processes) {
                
                var processStartTime = process.StartTime;

                var totalRunTime = startTime - processStartTime;

                if(totalRunTime.Minutes > lifetime)
                {
                    result.Add(process);
                }
            }
            return result;
        }

        public static async Task CloseTheProgramIfKeyIsPressedAsync(int frequence)
        {
            for(var index = 0; index < frequence * 60; index++)
            {
                await Task.Delay(1_000);

                if (Console.KeyAvailable)
                {
                    var inputKey = Console.ReadKey(intercept : true);

                    if (inputKey.Key == ConsoleKey.Q)
                    {
                        throw new StopProgramException();
                    }  
                }
            }
        }
    }
}

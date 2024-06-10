
namespace UtilityMonitorForWindows
{
    public static class ProcessMain
    {
        public static async Task RunAsync(string processName, int lifeTime, int frequency)
        {
            while (true)
            {
                try
                {
                    var processes = ProcessesHelper.GetAllProcessesThatCanBeKilled(processName, lifeTime);

                    foreach (var process in processes)
                    {
                        process.Kill();

                        Console.WriteLine($"Successfully closed the process: {process.Id}, {process.ProcessName}");
                    }

                    Console.WriteLine($"Done for searching processes. Retrying in {frequency} minutes");

                    await ProcessesHelper.CloseTheProgramIfKeyIsPressedAsync(frequency);

                }
                catch (StopProgramException) 
                {
                    Console.WriteLine("Exit the program");
                    break;
                }
            }

        }
    }
}

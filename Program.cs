using UtilityMonitorForWindows;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: ProcessName.exe <process_name> <max_lifetime_minutes> <monitor_frequency_minutes>");
            return;
        }

        string processName = args[0];

        if (!int.TryParse(args[1], out int maxLifetimeMinutes) || !int.TryParse(args[2], out int monitorFrequencyMinutes))
        {
            Console.WriteLine("Invalid arguments. Please provide numeric values for max_lifetime_minutes and monitor_frequency_minutes.");
            return;
        }

        var processMonitor = new ProcessMonitor();

        using (var cts = new CancellationTokenSource())
        {
            var keyButtonTask = Task.Run(() =>
            {
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    break;
                }
            }
        });

        Console.WriteLine($"Monitoring process: {processName}, Max lifetime: {maxLifetimeMinutes} minutes, Frequency: {monitorFrequencyMinutes} minutes");

            try
            {
                await processMonitor.StartMonitoringAsync(processName, maxLifetimeMinutes, monitorFrequencyMinutes, cts.Token);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Status: {ex.Message}");
            }
        }
    }
}
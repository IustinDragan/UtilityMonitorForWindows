using System.Diagnostics;

namespace UtilityMonitorForWindows
{
    public class ProcessMonitor
    {
        public async Task StartMonitoringAsync(string processName, int maxLifetimeMinutes, int monitorFrequencyMinutes, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var processes = Process.GetProcessesByName(processName);

                foreach (var process in processes)
                {
                    TimeSpan runtime = DateTime.Now - process.StartTime;

                    if (runtime.TotalMinutes > maxLifetimeMinutes)
                    {
                        try
                        {
                            Console.WriteLine($"[{DateTime.Now}] Killed process {process.ProcessName} (ID: {process.Id}), StartTime: {process.StartTime}, Runtime: {runtime.TotalMinutes:F2} minutes.");

                            process.Kill();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to kill process {process.ProcessName} (ID: {process.Id}): {ex.Message}");
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(monitorFrequencyMinutes), cancellationToken);
            }
        }
    }
}
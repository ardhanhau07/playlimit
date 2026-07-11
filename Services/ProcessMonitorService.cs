using System.Diagnostics;

namespace PlayLimit.Services;

public static class ProcessMonitorService
{
    public static bool IsRunning(string processName)
    {
        if (string.IsNullOrWhiteSpace(processName))
            return false;

        return Process.GetProcessesByName(processName).Length > 0;
    }
}
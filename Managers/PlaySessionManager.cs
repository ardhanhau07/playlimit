using PlayLimit.Models;
using PlayLimit.Services;

namespace PlayLimit.Managers;

public class PlaySessionManager
{
    private readonly UsageTrackerService _tracker = new();

    public void Update(IEnumerable<AppRule> rules)
    {
        foreach (var rule in rules)
        {
            if (!rule.Enabled)
                continue;

            if (ProcessMonitorService.IsRunning(rule.ProcessName))
            {
                _tracker.AddSecond(rule.ProcessName);

                rule.UsageSeconds =
                    _tracker.GetUsageSeconds(rule.ProcessName);
            }
        }
    }
}
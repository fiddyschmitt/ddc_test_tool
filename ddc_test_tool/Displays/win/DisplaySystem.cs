﻿using DDCKVMService;
using System.Text.RegularExpressions;

namespace SimpleKVM.Displays.win
{
    public static class DisplaySystem
    {
        static readonly Regex modelRegex = new Regex(@"model\((.*?)\)");
        static readonly Regex sourcesRegex = new Regex(@"(?<=\s)60\((.*?)\)");

        static List<Monitor>? cachedMonitorList;
        public static IList<Monitor> GetMonitors()
        {
            if (cachedMonitorList == null)
            {

                cachedMonitorList = new List<Monitor>();

                int monitorId = 0;
                MonitorController.GetDevices(physicalMonitors =>
                {
                    physicalMonitors
                                .ForEach(physicalMonitor =>
                                {
                                    var caps = physicalMonitor.GetVCPCapabilities();

                                    var model = "Unknown";
                                    var sources = new uint[0];
                                    if (caps != null)
                                    {
                                        model = modelRegex.Match(caps).Groups[1].Value;

                                        sources = sourcesRegex.Match(caps).Groups[1].Value.Split(' ')
                                                        .Where(x => !string.IsNullOrWhiteSpace(x))
                                                        .Select(x => Convert.ToUInt32(x, 16))
                                                        .ToArray();
                                    }

                                    physicalMonitor.GetVCPRegister(0x60, out uint currentSource);

                                    var newMonitor = new Monitor()
                                    {
                                        MonitorUniqueId = $"{++monitorId}",
                                        Model = model,
                                        ValidSources = sources.Cast<int>().ToList()
                                    };

                                    cachedMonitorList.Add(newMonitor);
                                });
                });
            }

            return cachedMonitorList;
        }
    }
}

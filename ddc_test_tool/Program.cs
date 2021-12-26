using CommandLine;
using ddc_test_tool.CLI;
using SimpleKVM.Displays.win;
using ddc_test_tool;

const string PROGRAM_NAME = "ddc_test_tool";
const string PROGRAM_VERSION = "1.1";

PrintProgramVersion();

var result = Parser.Default
                .ParseArguments<ListMonitorOptions, SetSourceOptions>(args)
                .MapResult(
                    (ListMonitorOptions opts) => ListMonitors(opts),
                    (SetSourceOptions opts) => SetMonitorInput(opts),
                    errs => 1);

return result;

static void PrintProgramVersion()
{
    string fullProgramName = $"{PROGRAM_NAME} v{PROGRAM_VERSION}";
    Console.WriteLine(fullProgramName);
}

static int ListMonitors(ListMonitorOptions options)
{
    var monitors = DisplaySystem.GetMonitors();

    Console.WriteLine($"{monitors.Count:N0} monitors found:");

    var monitorsStr = monitors
                         .Select(monitor =>
                         {
                             var validSourcesString = monitor
                                                         .ValidSources
                                                         .Select(s => "" + s)
                                                         .ToString(", ");

                             var monitorStr = $"\tMonitor {monitor.MonitorUniqueId}:    Model {monitor.Model}    Current source: {monitor.GetCurrentSource()}    Valid sources according to capability string: {validSourcesString}";

                             return monitorStr;
                         })
                         .ToString(Environment.NewLine);

    Console.WriteLine(monitorsStr);

    return 0;
}

static int SetMonitorInput(SetSourceOptions options)
{
    var monitors = DisplaySystem.GetMonitors();

    var monitor = monitors
                     .FirstOrDefault(monitor => monitor.MonitorUniqueId.Equals(options.MonitorUniqueID));

    if (monitor == null)
    {
        Console.WriteLine($"Error: Monitor '{options.MonitorUniqueID} not found. Please use --list to see a list of valid monitor IDs.");
        return 1;
    }
    else
    {
        monitor.SetSource(options.SourceID);
    }

    return 0;
}

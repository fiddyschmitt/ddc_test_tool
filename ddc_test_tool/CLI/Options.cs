using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddc_test_tool.CLI
{
    [Verb("list", HelpText = "List monitors.")]
    class ListMonitorOptions
    {
    }

    [Verb("set-source", HelpText = "Change the monitor's input to this source id.")]
    class SetSourceOptions
    {
        [Option('m', "monitor", Required = true, HelpText = "The unique ID of the monitor to change the input on.")]
        public string? MonitorUniqueID { get; set; }

        [Option('s', "source", Required = true, HelpText = "The source to change to. Typically 0 - 18 inclusive.")]
        public int SourceID { get; set; }
    }
}
